    public static int Count<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      ICollection collection = source as ICollection;
      if (collection != null)
        return collection.Count;
      int num = 0;
      foreach (TSource item in source)
          checked { ++num; }
      return num;
    }
