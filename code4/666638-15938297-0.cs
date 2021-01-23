    public Task<List<string>> ProcessTasksAsync(IEnumerable<string> data)
    {
        var contentTasks = ..........
        var tcs = new TaskCompletionSource<List<string>>();
        Task.Factory.ContinueWhenAll(contentTasks, tasks =>
        {
            var contentWeb = new List<string>(); // Build this in the continuation
            foreach (var task in tasks)
            {
                // ...same code...
                contentWeb.Add(task.Result.Content);
            }
            tcs.SetResult(contentWeb); // Set the task's result here
        });
        return tcs.Task;
    }
