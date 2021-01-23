    var cancellationTokenSource = new CancellationTokenSource();
    var tasks = new Task[threadsCount]
    for (int i = 0; i < threadsCount; i++)
    {
        tasks[i] = Task.Factory.StartNew(
            delegate
                {
                    // Do something
                }, cancellationTokenSource.Token);
    }
    try
    {
        Task.WaitAll(tasks);
    }
    catch (AggregateException ae)
    {
        cancellationTokenSource.Cancel();
        throw ae.InnerExceptions[0];
    }
