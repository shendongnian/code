    public static Task ForEachAsync<T>(this IEnumerable<T> source,
        int degreeOfParallelism, Func<T, Task> body)
    {
      var partitions = Partitioner.Create(source).GetPartitions(degreeOfParallelism);
      var tasks = partitions.Select(async partition =>
      {
        using (partition) 
          while (partition.MoveNext()) 
            await body(partition.Current); 
      });
      return Task.WhenAll(tasks);
    }
