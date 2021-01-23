    class Parent
    {
      public void Method1()
      {
        using(acquireLock())
        {
          Method1Impl();
        }
      }
      protected abstract IDisposable acquireLock();
      protected abstract void Method1Impl();
    }
    class Child : Parent
    {
       protected override IDisposable acquireLock()
       {
          // return some class that does appropriate locking 
          // and in Dispose releases the lock.
          // may even be no-op locking.
       }
    }
