    while(ApplicationIsRunning)
    {
      while(queue.HasWork)
      {
        WorkItem wi;
        lock(lockingObject)
        {
           wi = queue.NextWorkItem;
           if(!queue.HasWork)
           {
              signal.Reset();
           }
        }
        DoWork(wi)
      }
  
      signal.WaitOne();
    }
