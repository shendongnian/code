    public TaskThrottle(int initialCount, int maxTasksToRunInParallel)
    {
        _semaphore = new SemaphoreSlim(initialCount, maxTasksToRunInParallel);
    }
    public void TaskThrottler<T>(IEnumerable<Task<T>> tasks, int timeoutInMilliseconds, CancellationToken cancellationToken = default(CancellationToken)) where T : class
    {
            // Get Tasks as List
            var taskList = tasks as IList<Task<T>> ?? tasks.ToList();
            var semaphoreTasks = new List<Task<int>>();
            // When the first task completed, flag as done/release
            taskList.ForEach(x =>
            {
                semaphoreTasks.Add(x.ContinueWith(y => _semaphore.Release(), cancellationToken));
            });
            taskList.ForEach(async x =>
            {
                // It will not pass this until one free slot available or timeout occure  
                if(timeoutInMilliseconds > 0)
                    await _semaphore.WaitAsync(timeoutInMilliseconds, cancellationToken);
                else
                    await _semaphore.WaitAsync(cancellationToken);
                // Throws a OperationCanceledException if this token has had cancellation requested
                cancellationToken.ThrowIfCancellationRequested();
                // Start the task 
                x.Start();
            });
            Task.WaitAll(taskList.ToArray(), cancellationToken);
    }
