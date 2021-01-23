    class AsyncLogger:ILogger
    {
      public AsyncLogger(ILogger backingLogger)
      {
        new Thread(()=>
          {
            while(true)
            {
              var data=_queue.Take();
              _backingLogger.WriteData(data);
            }
          }
        ).Start();
      }
    
      public void WriteData(string data)
      {
         _queue.Enqueue(data);
      }
    }
