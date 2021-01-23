    Task[] tasks = new Task[3]
    {
        LoadTools(),
        LoadResources(),
        LoadPersonel()
    };
    Task.Factory.ContinueWhenAll(tasks, t =>
    {
        DataView = CollectionViewSource.GetDefaultView(Data);
        DataView.Filter = FilterTimelineData;
        IsBusy = false;
    }, CancellationToken.None, TaskContinuationOptions.None, 
       TaskScheduler.FromCurrentSynchronizationContext());
