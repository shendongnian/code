    void Foo()
    {
      bool lockTaken;
      try
      {
        Monitor.Enter(syncRoot, out lockTaken);
      }
      finally
      {
        if (lockTaken)
            Monitor.Exit(syncRoot);
      }
    }
