    private IObservable<bool> _status = Observable
        .Using(() => new Connection(),
               connection => Underlying.GetDeferredObservable(connection))
        .Publish()
        .RefCount();
    public IObservable<bool> Status { get { return _status; } }
