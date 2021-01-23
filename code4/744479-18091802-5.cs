    private async void LoadData()
    {
        SetBusy("Loading...");
        Data.Clear();
        Task[] tasks = new Task[3]
        {
            LoadTools(),
            LoadResources(),
            LoadPersonel()
        };
        await Task.WhenAll(tasks);
        DataView = CollectionViewSource.GetDefaultView(Data);
        DataView.Filter = FilterTimelineData;
        IsBusy = false;
    }
