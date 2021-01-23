    public static IEnumerable<T> WhereSource<T> ( this IEnumerable<T> source, Func<IEnumerable<T>, T, bool> predicate)
    {
      foreach (var item in source)
      {
        if (predicate(source, item))
        {
          yield return item;    
        }
      }
    }
