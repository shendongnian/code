    Task WhenAll(IEnumerable<Task> task)
    {
        return Task.Factory.Start(() => Task.WaitAll(tasks.ToArray()));
    }
    
