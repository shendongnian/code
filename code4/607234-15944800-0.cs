    class AutoDispose : IDisposable 
    { 
      Action _action; 
      public AutoDispose(Action action) 
      { 
        _action = action; 
      }
      public void Dispose()
      {
        _action();
      }
    }
    
    class Lock
    {
      SemaphoreSlim wrt = new SemaphoreSlim(1);
      int readcount=0;
    
      public IDisposable WriteLock()
      {
        wrt.Wait();
        return new AutoDispose(() => wrt.Release());
      }
     
      public IDisposable ReadLock()
      {
        if (Interlocked.Increment(ref readcount) == 1)
            wrt.Wait();
    
        return new AutoDispose(() => 
        {
          if (Interlocked.Decrement(ref readcount) == 0)
             wrt.Release();
        });
      }
    }
