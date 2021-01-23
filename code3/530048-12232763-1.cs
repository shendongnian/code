    public static int Count<T>(this IEnumerable<T> source)
    {
      var asCollT = source as ICollection<T>;
      if(asCollT != null)
        return asCollT.Count;
      var asColl = source as ICollection;
      if(asColl != null)
        return asColl.Count;
      int tally = 0;
      foreach(T item in source)
        ++tally;
      return tally;
    }
