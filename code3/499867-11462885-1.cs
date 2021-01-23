      public static IEnumerable<IEnumerable<T>> SplitBetween<T>(this IEnumerable<T> source, Func<T, bool> separatorSelector, bool includeSeparators = false)
      {
        var state = new SharedState<T>(source, separatorSelector, includeSeparators);
        state.LastList = state.NewList  = new InnerList<T>(state, 0);
        for (; ; )
        {
          if (state.NewList != null)
          {
            var newList = state.NewList;
            state.NewList = null;
            yield return newList.Items();            
          }
          else if (state.IsEnd)
            break;
          else
            state.CheckNext();
        }
      }
      class SharedState<T>
      {
        public SharedState(IEnumerable<T> source, Func<T, bool> separatorSelector, bool includeSeparators)
        {
          this.source = source;
          this.separatorSelector = separatorSelector;
          this.includeSeparators = includeSeparators;
          this.iterator = source.GetEnumerator();
          this.data = source as IList<T>;
          if (data == null)
          {
            cache = new List<T>();
            data = cache;
          }
        }
        public readonly IEnumerable<T> source;
        readonly IEnumerator<T> iterator; 
        public readonly IList<T> data;
        readonly List<T> cache;
        public readonly Func<T, bool> separatorSelector;
        public readonly bool includeSeparators;
        public int WaveIndex = -1;
        public bool IsEnd = false;
        public InnerList<T> NewList;
        public InnerList<T> LastList;
        public void CheckNext()
        {
          WaveIndex++;
          if (!iterator.MoveNext())
          {
            if (LastList.LastIndex == null)
              LastList.LastIndex = WaveIndex;
            IsEnd = true;
          }
          else
          {
            var item = iterator.Current;
            if (cache != null)
              cache.Add(item);
            if (separatorSelector(item))
            {
              LastList.LastIndex = includeSeparators ? WaveIndex + 1 : WaveIndex;
              LastList = NewList = new InnerList<T>(this, WaveIndex + 1);
            }
          }
        }
      }
      class InnerList<T>
      {
        public InnerList(SharedState<T> state, int startIndex)
        {
          this.state = state;
          this.StartIndex = startIndex;
        }
        readonly SharedState<T> state;
        public readonly int StartIndex;
        public int? LastIndex;
        public IEnumerable<T> Items()
        {
          for (var i = StartIndex; ; ++i)
          {
            if (LastIndex != null && i >= LastIndex)
              break;
            if (i >= state.WaveIndex)
              state.CheckNext();
            if (LastIndex == null || i < LastIndex)
              yield return state.data[i];
          }
        }
      }
