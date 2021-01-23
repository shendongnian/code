    public static async Task<IEnumerable<TResult>> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks, TimeSpan timeout)
    {
        if (tasks == null) throw new ArgumentNullException("tasks");
        if (timeout < TimeSpan.Zero) throw new ArgumentException("timeout");
        var timeoutTask = Task.Delay(timeout).ContinueWith(_ => default(TResult));
        var taskList = tasks.Concat(new[] {timeoutTask}).ToList();
        var results = new List<TResult>();
        var finishedTask = await Task.WhenAny(taskList);
        while (taskList.Count > 1 && finishedTask != timeoutTask)
        {
            results.Add(await finishedTask);
            taskList.Remove(finishedTask);
            finishedTask = await Task.WhenAny(taskList);
        }
        return results;
    }
