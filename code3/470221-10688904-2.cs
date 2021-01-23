    // the Task for the current application state
    Task<Result> _task;
    // a CancellationTokenSource for the current application state
    CancellationTokenSource _cts;
    // called when the application state changes
    void OnStateChange()
    {
        // cancel the Task for the old application state
        if (_cts != null)
        {
            _cts.Cancel();
        }
        // new CancellationTokenSource for the new application state
        _cts = new CancellationTokenSource();
        // start the Task for the new application state
        _task = Task.Factory.StartNew<Result>(() => { ... }, _cts.Token);
    }
    // called by UI component
    Task<Result> ComputeResultAsync(CancellationToken cancellationToken)
    {
        var task = _task;
        if (cancellationToken.CanBeCanceled && !task.IsCompleted)
        {
            task = WrapTaskForCancellation(cancellationToken, task);
        }
        return task;
    }
