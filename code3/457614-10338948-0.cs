    public class MySemaphore
    {
      private Semaphore underlying;
    
      public MySemaphore(int initialCount, int maximumCount)
      {
        underlying = new Semaphore(initialCount, maximumCount);
      }
      
      public bool WaitOne()
      {
        return underlying.WaitOne();
      }
    
      public int Release()
      {
        return underlying.Release();
      }
    
      public string Name { get; set; }
    }
