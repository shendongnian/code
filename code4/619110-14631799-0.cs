    public void RunAsync(Action onComplete, Action<Exception> errorHandler,
                         params Func<Task>[] actions)
    {
        RunAsync(onComplete, errorHandler, actions.AsEnumerable().GetEnumerator());
    }
    
    public void RunAsync(Action onComplete, Action<Exception> errorHandler,
                         IEnumerator<Func<Task>> actions)
    {
        if(!actions.MoveNext())
        {
            onComplete();
            return;
        }
        
        var task = actions.Current();
        task.ContinueWith(t => errorHandler(t.Exception),
                          TaskContinuationOptions.OnlyOnFaulted);
        task.ContinueWith(t => RunAsync(onComplete, errorHandler, actions),
                          TaskContinuationOptions.OnlyOnRanToCompletion);
    }
