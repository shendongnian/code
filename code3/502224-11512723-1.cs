    Task WhenAll(IEnumerable<Task> tasks)
    {
        return Task.Factory.StartNew(() => Task.WaitAll(tasks.ToArray()));
    }
    
