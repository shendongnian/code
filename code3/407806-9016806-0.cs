    private static void TimerHandler(object state)
    {
      if(!Monitor.TryEnter(LockObject))
        return;//last timer still running
      try
      {
        //do useful stuff here.
      }
      finally
      {
        Monitor.Exit(LockObject);
      }
    }
