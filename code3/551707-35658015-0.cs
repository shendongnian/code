    public static ConcurrentQueue<Exception> Parallel<T>(this IEnumerable<T> items, Action<T> action, int? parallelCount = null, bool debugMode = false)
    {
        var exceptions = new ConcurrentQueue<Exception>();
        if (debugMode)
        {
            foreach (var item in items)
            {
                try
                {
                    action(item);
                }
                // Store the exception and continue with the loop.                     
                catch (Exception e)
                {
                    exceptions.Enqueue(e);
                }
            }
        }
        else
        {
            var partitions = Partitioner.Create(items).GetPartitions(parallelCount ?? Environment.ProcessorCount).Select(partition => Task.Factory.StartNew(() =>
            {
                while (partition.MoveNext())
                {
                    try
                    {
                        action(partition.Current);
                    }
                    // Store the exception and continue with the loop.                     
                    catch (Exception e)
                    {
                        exceptions.Enqueue(e);
                    }
                }
            }));
            Task.WaitAll(partitions.ToArray());
        }
        return exceptions;
    }
