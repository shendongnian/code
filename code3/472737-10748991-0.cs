    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.ContinueWhenAll(tasks.ToArray(),
        result =>
        {
            // put you UI calls here
            
        }, CancellationToken.None, TaskContinuationOptions.None, ui);
