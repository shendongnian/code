    public static IEnumerable<IEnumerable<T>> Batch<T>(IEnumerable<T> collection, 
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
