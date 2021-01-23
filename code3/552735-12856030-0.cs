    var targetThreadDispatcher = Dispatcher.CurrentDispatcher;
    var tokenSource = new CancellationTokenSource();
    Task.Factory.StartNew(() => 
    {
    	Task.Delay(TimeSpan.FromSeconds(5));
    	targetThreadDispatcher.Invoke(() => 
    	{
    		throw new MyExceptionClass();
    	}
    }, tokenSource.Token);
    
    RunProcess();
    tokenSource.Cancel();
	
