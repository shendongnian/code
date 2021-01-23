    var state = new object();
    var cancellationTokenSource = new CancellationTokenSource();
    var cancellationToken = cancellationTokenSource.Token;
    
    var task = Task.Factory.StartNew(
        objState => { Console.WriteLine ("Current thread is {0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(30); },
        state,
        cancellationToken,
        TaskCreationOptions.LongRunning,
        TaskScheduler.Current);
        
    task.Wait();    
