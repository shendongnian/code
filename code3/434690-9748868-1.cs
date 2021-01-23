    void ShortUIWork()
    {
        Debug.Assert(this.Dispatcher.CheckAccess() == true);
        Task.Factory.StartNew(LongWork, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }
