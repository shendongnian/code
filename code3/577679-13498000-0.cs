    public static IEnumerable<List<T>> ToBatches<T>(this List<T> list, int batchSize)
    {
        int index = 0;
        List<T> batch = new List<T>();
        foreach (T item in list)
        {
            batch.Add(item);
    
            index++;
            if (index == batchSize)
            {
                index = 0;                
                yield return batch;
                batch = new List<T>();
            }
        }
    
        yield return batch;
    }
