    private readonly Subject<IObservable<EventPattern<EventArgs>> _contexts = new Subject<IObservable<EventPattern<EventArgs>>();
    private readonly IObservable<EventPattern<EventArgs>> _saves = _contexts.Merge();
    public IObservable<EventPattern<EventArgs>> Saves { get { return _saves; } }
    public void AttachContext(DbContext context)
    {
        _contexts.OnNext(Observable.FromEventPattern<EventArgs>(((IObjectContextAdapter)context).ObjectContext, "SavingChanges"));
    }
