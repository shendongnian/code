    var targetThreadDispatcher = Dispatcher.CurrentDispatcher;
    var tokenSource = new CancellationTokenSource();
    var cancellationToken = tokenSource.Token;
    Task.Factory.StartNew(() => 
    {
        var ct = cancellationToken;
        // How long the process has to run
        Task.Delay(TimeSpan.FromSeconds(5));
        // Exit the thread if the process completed
        ct.ThrowIfCancellationRequest();
        // Throw exception to target thread
        targetThreadDispatcher.Invoke(() => 
        {
            throw new MyExceptionClass();
        }
    }, cancellationToken);
    
    RunProcess();
    
    // Cancel the exception raising if the process was completed.
    tokenSource.Cancel();
