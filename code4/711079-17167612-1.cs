    public static IEnumerable Batch<T>(this IList<T> source, int maxSize)
    {
        if (source == null)
            throw new NullReferenceException("Batch cannot be null");
        var batch = new List<T>();
        foreach (var item in source)
        {
            batch.Add(item);
            if (batch.Count == maxSize)
            {
                yield return batch;
                batch = new List<T>();
            }
        }
        if (batch.Any())
        {
            yield return batch;
        }
    }
