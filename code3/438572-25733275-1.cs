    public static async Task<IEnumerable<TResult>> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks,
        TimeSpan timeout)
    {
        if (tasks == null) throw new ArgumentNullException("tasks");
        if (timeout < TimeSpan.Zero) throw new ArgumentException("timeout");
        var results = new List<TResult>();
        var timeoutTask = Task.Delay(timeout).ContinueWith(_ => default(TResult));
        var completedTasks =
            from task in await Task.WhenAll(tasks.Select(task => Task.WhenAny(task, timeoutTask)))
            where task != timeoutTask
            select task;
        foreach (var completedTask in completedTasks)
        {
            results.Add(await completedTask);
        }
        return results;
    }
