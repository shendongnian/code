    Monitor.Enter(someObj);
    try
    {
      int uselessDemoCode = 3;
    }
    finally
    {
      Monitor.Exit(someObj);
    }
