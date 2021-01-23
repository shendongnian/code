    public async Task<int> GetIntAsync()
    {
        var childrenTask = Task.WhenAll();
        
        while (...)
        {
            ...
            childrenTask = Task.WhenAll(Task.Run(...), childrenTask);
            ...
        }
        
        await childrenTask;
        
        return 1;
    }
