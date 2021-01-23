    private object locker = new object();
    
    public void Method()
    {
      lock(locker)
      {
        lock(locker)
        {
        }
      }
    }
