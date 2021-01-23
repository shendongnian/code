    private AsyncLock mutex = new AsyncLock();
    private Task executing;
    public async Task CallThisOnlyOnceAsync()
    {
      Task action = null;
      using (await mutex.LockAsync())
      {
        if (executing == null)
          executing = DoCallThisOnlyOnceAsync();
        action = executing;
      }
      await action;
    }
    private async Task DoCallThisOnlyOnceAsync()
    {
      PropagateSomeEvents();
      await SomeOtherMethod();
      PropagateDifferentEvents();
      using (await mutex.LockAsync())
      {
        executing = null;
      }
    }
