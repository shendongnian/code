    static void PerformBatchedOperation<T>(IEnumerable<T> items, Action<IEnumerable<T>> operation)
    {
        List<T> batch = new List<T>();
        int i = 0;
        foreach (T item in items)
        {
            i++;
            batch.Add(item);
    
            if (i == 1000)
            {
                operation(batch);
                batch.Clear();
                i = 0;
            }
        }
    
        // Process last batch
        if (i != 0)
        {
            operation(batch);
        }
    }
