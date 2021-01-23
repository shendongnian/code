    public static IEnumerable<T> Distinct(IEnumerable<T> src, IEqualityComparer<T> eCmp)
    {
      Dictionary<T, bool> fakeHashSet = new Dictionary<T, bool>(eCmp);
      //When I coded for 2.0 I had my own custom HashSet<T>, but that's overkill here
      bool dummy;
      foreach(T item in src)
      {
        if(!fakeHashSet.TryGetValue(item, out dummy))
        {
          fakeHashSet.Add(item, true);
          yield return item;
        }
      }
    }
    public static IEnumerable<T> Distinct(IEnumerable<T> src)
    {
      return Distinct(src, EqualityComparer<T>.Default);
    }
    public delegate TResult Func<T, TResult>(T arg);//we don't even have this :(
    public static int Count(IEnumerable<T> src, Func<T, bool> predicate)
    {
      int c = 0;
      foreach(T item in src)
        if(predicate(item))
          ++c;
      return c;
    }
