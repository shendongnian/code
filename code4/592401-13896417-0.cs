    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    CancellationToken cancellationToken = cancellationTokenSource.Token;
    Task task = new Task(() =>
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine("Task 2 - Int value {0}", i);
        }
    }, cancellationToken);
    task.Start();
    cancellationTokenSource.Cancel();
    try
    {
        task.Wait();
    }
    catch (AggregateException ae)
    {
        if(ae.InnerExceptions.Single() is TaskCanceledException)
            Console.WriteLine("Caught TaskCanceledException");
        else
            Console.WriteLine("Did not catch canceled");
    }
    Console.WriteLine("Task 2 cancelled? {0}", task.IsCanceled);
