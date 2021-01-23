    Task DoSyncAsync()
    {
      var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
      var factory = new TaskFactory(scheduler);
      return Task.Run(() => DoSync(factory));
    }
    void DoSync(TaskFactory factory)
    {
      ...
      scheduler.StartNew(() => { ... });
      ...
    }
