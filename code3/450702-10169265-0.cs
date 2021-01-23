    string s = "[YOUR DATA]";
    var lines = s.Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    foreach(var batch in lines.Batch(20))
    {
      foreach(batchLine in batch)
      {
        Console.Writeline(batchLine);
      }
    }
    static class LinqEx
    {
      // from http://www.make-awesome.com/2010/08/batch-or-partition-a-collection-with-linq
      public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> collection,
                    int batchSize)
      {
        List<T> nextbatch = new List<T>(batchSize);
        foreach (T item in collection)
        {
          nextbatch.Add(item);
          if (nextbatch.Count == batchSize)
          {
            yield return nextbatch;
            nextbatch = new List<T>(batchSize);
          }
        }
        if (nextbatch.Count > 0)
          yield return nextbatch;
      }
    }
