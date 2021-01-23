    var scheduler = new LimitedConcurrencyLevelTaskScheduler(5);
    TaskFactory factory = new TaskFactory(scheduler);
    while( !actionQueue.IsEmpty )
    {
        factory.StartNew( () =>
        {
            Action action;
            if(actionExecution.TryDequeue(out action))                
                action.Invoke();
            
        }, TaskCreationOptions.LongRunning);
    }
    
