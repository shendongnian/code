     public SampleViewModel()
     {
        IsBusy = true;
        new Task(() =>
        {
            var task1 = new Task(() => LoadProp1Async());
            var task2 = new Task(() => LoadProp2Async());
            var task3 = new Task(() => LoadProp3Async());
            task1.Start();
            task2.Start();
            task3.Start();
            Task.WaitAll(task1, task2, task3);
            IsBusy = false;
        }).Start();
     }
