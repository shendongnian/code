    // locking object for write synchronization
    object syncObj;
    
    ...
    public TaskSpin(Func asyncMethod, object[] methodParameters)
    {
        ...
        asyncTask = Task.Factory.StartNew<bool>(() => 
            asyncMethod(uiScheduler, methodParameters));
    
        asyncTask.ContinueWith(task =>
        {
            lock(syncObj)
            {
                // Finish the processing update UI etc.
            }
        }
        ...
    }
    
    public void Run()
    {
        lock(syncObj)
        {
            // write results to common file
        }
    }
