    var cts = new CancellationTokenSource();
    var token = cts.Token;
    var task = Task.Factory.StartNew(() =>
    {
        // Do Job Step 1...
        if (token.IsCancellationRequested) return;
    	// Do Job Step 2...
        // ...
    }, token);
    
    // Later, to kill all the tasks and their children, simply:
    cts.Cancel();
