    object lockObject = new object();
    private void ProcessTimerEvent(object state) 
     {
      if (Monitor.TryEnter(lockObject))
      {
       try
       {
       // Work here
       }
       finally
        {
       Monitor.Exit(lockObject);
        }
       }
      }
