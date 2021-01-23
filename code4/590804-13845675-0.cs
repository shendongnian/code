    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source
        , int batchSize)
    {
        //TODO validate parameters
        List<T> buffer = new List<T>();
    
        foreach (T item in source)
        {
            buffer.Add(item);
    
            if (buffer.Count >= batchSize)
            {
                yield return buffer;
                buffer = new List<T>();
            }
        }
        if (buffer.Count >= 0)
        {
            yield return buffer;
        }
    }
