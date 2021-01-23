    Task.Factory.StartNew(
        () =>
        {
            // Do some work that may throw.
            // This code runs on the Threadpool.
            // Any exceptions will be propagated
            // to continuation tasks and awaiters
            // for observation.
            throw new StackOverflowException(); // :)
        }
    ).ContinueWith(
        (a) =>
        {
            // Handle your exception here.
            // This code runs on the thread
            // that started the worker task.
            if (a.Exception != null)
            {
                foreach (var ex in a.Exception.InnerExceptions)
                {
                    // Try to handle or throw.
                }
            }
        },
        CancellationToken.None,
        TaskContinuationOptions.None,
        TaskScheduler.FromCurrentSynchronizationContext()
    );
