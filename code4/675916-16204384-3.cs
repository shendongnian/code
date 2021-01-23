    class Resource
    {
      private readonly RecursiveAsyncLock mutex = new RecursiveAsyncLock();
      public RecursiveLockAsync.RecursiveLockAwaitable LockAsync(bool immediate = false)
      {
        if (immediate)
          return mutex.LockAsync(new CancellationToken(true));
        return mutex.LockAsync();
      }
    }
    async void button1Click(..)
    {
      using (r.LockAsync(true))
      {
        ... // mess with r
        await _IndependentResourceModiferAsync();
      }
    }
    async void button2Click(..)
    {
      using (r.LockAsync(true))
      {
        await _IndependentResourceModiferAsync();
      }
    }
    async Task _IndependentResourceModiferAsync()
    {
      using (await r.LockAsync())
      {
        ...
      }
    }
