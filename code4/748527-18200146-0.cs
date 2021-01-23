    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> t, int size)
    {
       while (t.Any())
       {
          yield return t.Take(size);
          t = t.Skip(size);
       }
    }
