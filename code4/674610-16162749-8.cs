    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.ContinueWhenAll(tasks.ToArray(),
        result =>
        {
            var time = watch.ElapsedMilliseconds;
            label1.Content += time.ToString();
        }, CancellationToken.None, TaskContinuationOptions.None, ui);
