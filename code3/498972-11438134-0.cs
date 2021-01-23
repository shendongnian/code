    // Allow for cancellation.
    CancellationTokenSource cancelSource = new CancellationTokenSource();
    CancellationToken token = new CancellationToken();
    TaskCreationOptions atp = TaskCreationOptions.AttachedToParent; 
    
    List<Bar> allResults = new List<Bar>();
    Task<List<Bar>> asyncTask = Task.Factory.StartNew<List<Bar>>(() => asyncMethod(token, atp), token);
    
    // Continuation is returned when the asyncMethod is complete.
    asyncTask.ContinueWith(task =>
    {
        // Handle the result.
        switch (task.Status)
        {
            // Handle any exceptions to prevent UnobservedTaskException.             
            case TaskStatus.RanToCompletion:
                break;
            case TaskStatus.Canceled:
                break;
            case TaskStatus.Faulted:
        }
    }
    
