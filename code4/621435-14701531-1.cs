    private static readonly object lockObj = new Object();
    public void Do(int userId)
    {
         Monitor.Enter(lockObj);
         
         if (userId != 1)
              Monitor.Exit(lockObj);
         try
         {
            DoIt();
         }
         finally 
         {
             if (userId == 1)
                 Monitor.Exit(lockObj);
         }
    }
    public void DoIt()
    {
        // Do It
    }
