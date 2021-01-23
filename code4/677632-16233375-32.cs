    public void ProcessDataFromQueue<T>(BlockingCollection<T[]> queue) where T : struct
    {
        foreach (var array in queue.GetConsumingEnumerable())
        {
            // Do something with 'array'
        }
    }
