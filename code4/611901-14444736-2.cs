    using System.Collections.Concurrent;
    using System.Threading;
    public sealed class QueuedEventLogger : Logger, ILogger
    {
      ConcurrentQueue<string> queuedLines = new ConcurrentQueue<string>();
      Action<string> onLineLogged;
      Thread queueThread;
      public QueuedEventLogger(Action<string> onLineLogged)
      {
        this.onLineLogged = onLineLogged;
        InitializeThread();
      }
      public override void Log(string line)
      {
        queuedLines.Enqueue(line);
      }
      void InitializeThread()
      {
        queueThread = new Thread(); 
        queueThread.IsBackground = true;
        queueThread.Start(()=>
        {
          while(true)
          {
            string line = null;
            if(queuedLines.TryDequeue(out line) && onLineLogged != null)
               onLineLogged(line);
            Thread.Sleep(1);
          }
        });
      }
    }
