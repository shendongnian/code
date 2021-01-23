    class ConditionVariable
    {
      private int waiters = 0;
      private object waitersLock = new object();
      private SemaphoreSlim sema = new SemaphoreSlim(0, Int32.MaxValue); 
      
      public ConditionVariable() { 
      }
      
      public void Pulse() {
          bool release;
          lock (waitersLock)
          {
             release = waiters > 0;
          }
          if (release) {
            sema.Release();
          }
      }
      
      public void Wait(object cs) {
        lock (waitersLock) {
          ++waiters;
        }
        Monitor.Exit(cs);
        sema.Wait();
        lock (waitersLock) {
          --waiters;
        }
        Monitor.Enter(cs);
      }
    }
