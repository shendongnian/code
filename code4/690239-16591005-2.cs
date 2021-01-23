    System.Reactive.Linq.Observable.FromEventPattern<Windows.ApplicationModel.Search.SearchPaneSuggestionsRequestedEventArgs>
        (Windows.ApplicationModel.Search.SearchPane.GetForCurrentView(), "SuggestionsRequested")
        .Throttle(TimeSpan.FromMilliseconds(500), System.Reactive.Concurrency.Scheduler.CurrentThread)
        .Where(x => x.EventArgs.QueryText.Length > 3)
        .DistinctUntilChanged(x => x.EventArgs.QueryText.Trim())
        .Subscribe(x => HandleSuggestions(x.EventArgs));
