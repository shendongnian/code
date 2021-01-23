    static IEnumerable<T> Map<T>(Func<IEnumerable<T>, T> f, 
                                 params IEnumerable<T>[] arr)
    {
      var enums = Array.ConvertAll(arr, x => x.GetEnumerator());
      try
      {
        while (enums.All(x => x.MoveNext()))
        {
          yield return f(enums.Select(x => x.Current));
        }
      }
      finally
      {
        foreach (var e in enums) e.Dispose();
      }
    }
    
    static void Main(string[] args)
    {
      double[] w = { 1, 2, 3, 4, 5 };
      double[] x = { 1, 3, 5, 6, 6 };
      double[] y = { 5, 6, 8, 3, 4 };
      double[] z = { 9, 4, 10, 0, 8 };
    
      var r = Map(Enumerable.Max, w, x, y, z).ToArray();
    
      ...
    }
