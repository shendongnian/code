    Observable.Interval(TimeSpan.FromMinutes(5))
            .StartWith(-1L)
            .ObserveOn(Scheduler.ThreadPool)
            .Where(i => IsProcessing)     // IsProcessing is the bool value
            .Subscribe(GetFeeds, OnError, OnComplete);
