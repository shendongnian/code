    public void RunSequential(Action onComplete, Action<Exception> errorHandler,
                              params Func<Task>[] actions)
    {
        RunSequential(onComplete, errorHandler,
                      actions.AsEnumerable().GetEnumerator());
    }
    
    public void RunSequential(Action onComplete, Action<Exception> errorHandler,
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
        task.ContinueWith(t => RunSequential(onComplete, errorHandler, actions),
                          TaskContinuationOptions.OnlyOnRanToCompletion);
    }
