    public TaskThrottle(int maxTasksToRunInParallel)
    {
        _semaphore = new SemaphoreSlim(maxTasksToRunInParallel);
    }
    public void TaskThrottler<T>(IEnumerable<Task<T>> tasks, int timeoutInMilliseconds, CancellationToken cancellationToken = default(CancellationToken)) where T : class
    {
        // Get Tasks as List
        var taskList = tasks as IList<Task<T>> ?? tasks.ToList();
        var postTasks = new List<Task<int>>();
        // When the first task completed, it will flag 
        taskList.ForEach(x =>
        {
            postTasks.Add(x.ContinueWith(y => _semaphore.Release(), cancellationToken));
        });
        taskList.ForEach(x =>
        {
            // Wait for open slot 
            _semaphore.Wait(timeoutInMilliseconds, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            x.Start();
        });
        Task.WaitAll(taskList.ToArray(), cancellationToken);
    }
