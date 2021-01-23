    public async Task<List<string>> ProcessTasksAsync(IEnumerable<string> data)
    {
        var contentTasks = ..........
        await Task.WhenAll(contentTasks);
        var contentWeb = new List<string>(); // Build this in the continuation
        foreach (var task in contentTasks)
        { 
            // ...same code...
            contentWeb.Add(task.Result.Content);
        }
        return contentWeb;
    }
