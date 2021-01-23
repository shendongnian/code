    class Test
    {
      private object syncObj = new object();
      private bool state = false;
      private Timer stateTimer;
    
      public Test()
      {
        stateTimer = new Timer(ResetState, this, Timeout.Infinite, Timeout.Infinite);
      }
    
      public void SetState()
      {
        lock(syncObj)
        {
          state = true;
          stateTimer.Change(1000, Timeout.Infinite);    
        }
      }
      public static void ResetState(object o)
      {
        Test t = o as Test;
        t.ResetState();
      }  
