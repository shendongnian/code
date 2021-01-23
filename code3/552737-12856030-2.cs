    var targetThreadDispatcher = Dispatcher.CurrentDispatcher;
    var tokenSource = new CancellationTokenSource();
    var cancellationToken = tokenSource.Token;
    Task.Factory.StartNew(() => 
    {
		var ct = cancellationToken;
        var end = DateTime.Now.AddSeconds(5);
        while(DateTime.Now < end)
        {
            Task.Delay(TimeSpan.FromSeconds(1));
            ct.ThrowIfCancellationRequest();
        }
        targetThreadDispatcher.Invoke(() => 
        {
            throw new MyExceptionClass();
        }
    }, cancellationToken);
    
    RunProcess();
    
    // Cancel the exception raising if the process was completed.
    tokenSource.Cancel();
