    static void CancelWithThreadPoolMiniSnippet()
    {
    //Thread 1: The Requestor 
    // Create the token source.
    CancellationTokenSource cts = new CancellationTokenSource();
    // Pass the token to the cancelable operation.
    ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomeWork), cts.Token);
    // Request cancellation by setting a flag on the token.
        cts.Cancel();
    }
    
    //Thread 2:The Listener 
    static void DoSomeWork(object obj)
    {
        CancellationToken token = (CancellationToken)obj;
        for (int i = 0; i < 100000; i++)
        {
            // Simulating work.
            Thread.SpinWait(5000000);
    
            if (token.IsCancellationRequested)
            {
                // Perform cleanup if necessary. 
                //... 
                // Terminate the operation. 
                break;
            }
        }
    }
