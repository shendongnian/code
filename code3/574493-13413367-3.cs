    public DispatcherOperation InvokeAsync(Action callback, DispatcherPriority priority)
    {
        return this.InvokeAsync(callback, priority, CancellationToken.None);
    }
    public DispatcherOperation InvokeAsync(Action callback, DispatcherPriority priority, CancellationToken cancellationToken)
    {
        if (callback == null)
        {
            throw new ArgumentNullException("callback");
        }
        Dispatcher.ValidatePriority(priority, "priority");
        DispatcherOperation dispatcherOperation = new DispatcherOperation(this, priority, callback);
        this.InvokeAsyncImpl(dispatcherOperation, cancellationToken);
        return dispatcherOperation;
    }
