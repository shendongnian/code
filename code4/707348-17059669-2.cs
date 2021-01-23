    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
    {
        for (int i = 0; i < source.Count(); i+=batchSize)
        {
            yield return source.Skip(i).Take(batchSize);
        }
    }
