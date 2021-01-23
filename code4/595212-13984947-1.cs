    private object locker = new object();
    
    public void Method()
    {
      lock(locker)
      {
        lock(locker) { Console.WriteLine("Re-entered the lock."); }
      }
    }
