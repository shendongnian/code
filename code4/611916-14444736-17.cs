    using System.Collections.Concurrent;
    using System.Threading;
    public sealed class QueuedEventLogger : Logger, ILogger, IDisposable
    {
      bool isDisposed;
      BlockingCollection queuedLines;
      Action<string> onLineLogged;
      Thread queueThread;
      
      public QueuedEventLogger(Action<string> onLineLogged)
      {
        var queue = new ConcurrentQueue<string>();
        queuedLines = new BlockingCollection(queue);
        this.onLineLogged = onLineLogged;
        InitializeThread();
      }
      public void Dispose()
      {
        Dispose(true);
        GC.SurpressFinalize(this);
      }
      void Dispose(bool isDisposing)
      {
        if(isDisposed) return;
         
        if(isDisposing)
        {
          if(queueThread != null && queueThread.IsAlive)
            queueThread.Abort();
          if(queuedLines != null)
            queuedLines.Dispose();
        }
        isDisposed = true;
      }
      public override void Log(string line)
      {
        queuedLines.Add(line);
      }
      void InitializeThread()
      {
        queueThread = new Thread(); 
        queueThread.IsBackground = true;
        queueThread.Start(()=>
        {
          while(true)
          {
            string line = lineCollection.Take();
           
            if(onLineLogged != null)
              onLineLogged(line);           
          }
        });
      }
    }
