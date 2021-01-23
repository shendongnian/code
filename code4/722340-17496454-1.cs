    public IDisposable AttachContext(DbContext context)
    {
        var detachSignal = new AsyncSubject<Unit>();
        var disposable = Disposable.Create(() =>
        {
            detachSignal.OnNext(Unit.Default);
            detachSignal.OnCompleted();
        });
        var events = Observable.FromEventPattern<EventArgs>(((IObjectContextAdapter)context).ObjectContext, "SavingChanges");
        _contexts.OnNext(events.TakeUntil(detachSignal));
        return disposable;
    }
