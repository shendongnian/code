    while(ApplicationIsRunning)
    {
      while(queue.HasWork)
      {
        DoWork(queue.NextWorkItem)
      }
  
      lock(lockingObject)
      {
        signal.Reset();
        signal.WaitOne();
      }
