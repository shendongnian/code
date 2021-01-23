    public async Task<int> GetIntAsync()
    {
        var childTasks = new List<Task>();
        
        while (...)
        {
            ...
            childTasks.Add(Task.Run(...));
            ...
        }
        
        await Task.WhenAll(childTasks);
        
        return 1;
    }
