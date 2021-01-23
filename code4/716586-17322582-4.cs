    var cts = new CancellationTokenSource();
    var token = cts.Token;
    var task = Task.Run(() =>
    {
        // Do Job Step 1...
        if (token.IsCancellationRequested)
        {
            // Handle cancellation here, if necessary.
            // Thanks to @svick - this will set the Task status to Cancelled
            // by throwing OperationCanceledException inside it.
            token.ThrowIfCancellationRequested();
        }
    	// Do Job Step 2...
        // ...
    }, token);
    
    // Later, to kill all the tasks and their children, simply:
    cts.Cancel();
