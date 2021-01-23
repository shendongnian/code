    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.ContinueWhenAll(tasks.ToArray(),
        result =>
        {
            // Put you UI calls here
        }, CancellationToken.None, TaskContinuationOptions.None, ui);
