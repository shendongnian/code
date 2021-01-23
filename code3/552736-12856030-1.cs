    var targetThreadDispatcher = Dispatcher.CurrentDispatcher;
    var tokenSource = new CancellationTokenSource();
    var cancellationToken = tokenSource.Token;
    Task.Factory.StartNew(() => 
    {
        // How long the process can run without throwing
        Task.Delay(TimeSpan.FromSeconds(5));
        // If the process has completed, throw an exception to exit this task
        cancellationToken.ThrowIfCancellationRequested();
        // Throw the exception on the source thread
        targetThreadDispatcher.Invoke(() => 
        {
            throw new MyExceptionClass();
        }
    }, cancellationToken);
    
    RunProcess();
    
    // Cancel the exception raising if the process was completed.
    tokenSource.Cancel();
