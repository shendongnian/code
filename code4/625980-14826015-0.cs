     public SampleViewModel()
     {
        IsBusy = true;
        var task1 = Task.Run(() => LoadProp1Async());
        var task2 = Task.Run(() => LoadProp2Async());
        var task3 = Task.Run(() => LoadProp3Async());
        Task.WhenAll(task1, task2, task3).ContinueWith(t => IsBusy = false);
     }
