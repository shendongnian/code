    private Queue<IList<Tuple<Thing,ThingEventType>>> _eventQueue;
    private static object SyncRoot = new object();
    _eventQueue = new Queue<IList<Tuple<Thing,ThingEventType>>>();
    // A serial disposable is a sort of "Disposable holder" - when you change it's
    // Disposable member, it auto-disposes what you originally had there...no real
    // need for it here, but potentially useful later
    _watcherDisposable = new SerialDisposable();
    _watcherDisposable.Disposable = _buffer
        .ObserveOn(_scheduler)
        .Subscribe(batch => 
        { 
            lock(SyncRoot) { _eventQueue.Enqueue(batch); }
        });
        _disposables.Add(_watcherDisposable);
