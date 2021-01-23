    void ShortUIWork()
    {
        Debug.Assert(this.Dispatcher.CheckAccess() == true);
        Task.Factory.StartNew(LongWork, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
    }
