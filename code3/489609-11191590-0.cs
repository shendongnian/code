    var processing = Observable
        .FromEventPattern<PropertyChangedEventArgs>(this, "PropertyChanged")
        .Where(tr => tr.EventArgs.Property == "IsProcessing" && ((Type)tr.Sender).IsProcessing);
    
    _queryDisposable = Observable
        .Interval(TimeSpan.FromMinutes(5))
        .ObserveOn(Scheduler.ThreadPool)
        .And(processing) // Will only fire when both sequences have an available value.
        .Subscribe(GetFeeds, OnError, OnComplete);
