    while (IsThreadRunning)
    {
      while ( DataQueue.Count > 0 )
      {
        DataQueue.Dequeue();
      }
      ResetEvent.WaitOne();
      ResetEvent.Reset();
    }
