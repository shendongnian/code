    class Resource
    {
      private readonly SemaphoreSlim mutex = new SemaphoreSlim(1);
      // Take the lock immediately, throwing an exception if it isn't available.
      public IDisposable ImmediateLock()
      {
        if (!mutex.Wait(0))
          throw new InvalidOperationException("Cannot acquire resource");
        return new AnonymousDisposable(() => mutex.Release());
      }
      // Take the lock asynchronously.
      public async Task<IDisposable> LockAsync()
      {
        await mutex.WaitAsync();
        return new AnonymousDisposable(() => mutex.Release());
      }
    }
    async void button1Click(..)
    {
      using (r.ImmediateLock())
      {
        ... // mess with r
        await _IndependentResourceModiferUnsafeAsync();
      }
    }
    async void button2Click(..)
    {
      using (r.ImmediateLock())
      {
        await _IndependentResourceModiferUnsafeAsync();
      }
    }
    async Task _IndependentResourceModiferAsync()
    {
      using (await r.LockAsync())
      {
        await _IndependentResourceModiferUnsafeAsync();
      }
    }
    async Task _IndependentResourceModiferUnsafeAsync()
    {
      ... // code here assumes it owns the resource lock
    }
