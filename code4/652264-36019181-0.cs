    public async Task MyAsyncMethod()
    {
        // do some stuff async, don't return any data
    }
    public string GetStringData()
    {
        // Run async, no warning, exception are catched
        RunAsync(MyAsyncMethod()); 
        return "hello world";
    }
    private void RunAsync(Task task)
    {
        task.ContinueWith(t =>
        {
            ILog log = ServiceLocator.Current.GetInstance<ILog>();
            log.Error("Unexpected Error", t.Exception);
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
