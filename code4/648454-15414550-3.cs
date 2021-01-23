    static void PerformBatchedOperation<T>(IEnumerable<T> items, 
                                           Action<IEnumerable<T>> operation, 
                                           int batchSize)
    {
        List<T> batch = new List<T>();
        foreach (T item in items)
        {
            batch.Add(item);
    
            if (batch.Count == batchSize)
            {
                operation(batch);
                batch.Clear();
            }
        }
    
        // Process last batch
        if (batch.Any())
        {
            operation(batch);
        }
    }
