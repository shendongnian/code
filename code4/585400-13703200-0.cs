    [Serializable]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
          private List<T> list;
          private int index;
          private int version;
          private T current;
    
          public T Current
          {
            get
            {
              return this.current;
            }
          }
    
          ....
    
          internal Enumerator(List<T> list)
          {
            this.list = list;
            this.index = 0;
            this.version = list._version;
            this.current = default (T); //there are default of T
          }
    
          ....
        }
