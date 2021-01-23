    Monitor.Enter(obj);
    try
    {
      //Do Stuff;
    }
    finally
    {
      Monitor.Exit(obj);
    }
