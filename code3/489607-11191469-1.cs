        Subscribe(GetFeeds, OnError, OnComplete);
        // Or perhaps, if you want it to be async,
        new TaskFactory().StartNew(()=>Subscribe(GetFeeds, OnError, OnComplete));
        _queryDisposable = Observable
            .Interval(TimeSpan.FromMinutes(5))
            .ObserveOn(Scheduler.ThreadPool)
            .Where(i => IsProcessing)     // IsProcessing is the bool value
            .Subscribe(GetFeeds, OnError, OnComplete);
