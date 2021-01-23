    var context = TaskScheduler.FromCurrentSynchronizationContext();
    var task = new Task<TResult>(() =>
        {
            TResult TResult = ...;
            return TResult;
        });
        
    task.ContinueWith(t =>
        {
            // Update UI (and UI-related data) here: success status.
            // t.Result contains the result.
        },
        CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, context);
    task.ContinueWith(t =>
        {
            AggregateException aggregateException = t.Exception;
            aggregateException.Handle(exception => true);
            // Update UI (and UI-related data) here: failed status.
            // t.Exception contains the occured exception.
        },
        CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, context);
    task.Start();
