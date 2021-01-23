    // the Task for the current application state
    Task<Result> _task;
    // a CancellationTokenSource for the current application state
    CancellationTokenSource _cts;
    // called when the application state changes
    void OnStateChange()
    {
        // cancel Task for old application state
        if (_cts != null)
            _cts.Cancel();
        // new CancellationTokenSource for the new application state
        _cts = new CancellationTokenSource();
        // new pending Task for the new application state
        _task = new Task<Result>(() => { ... }, _cts.Token);
    }
    // called by UI component
    Task<Result> ComputeResultAsync(CancellationToken cancellationToken)
    {
        var task = _task;
        if (task.Status == TaskStatus.Created)
            task.Start();
        if (ct.CanBeCanceled && !task.IsCompleted)
            task = WrapTaskForCancellation(cancellationToken, task);
        return task;
    }
