    using System.Collections.Concurrent;
    using System.Threading;
    using System.Windows.Thread;
    public sealed class QueuedEventLogger : Logger, ILogger
    {
      ConcurrentQueue<string> queuedLines = new ConcurrentQueue<string>();
      Action<string> onLineLogged;
      Thread queueThread;
      
      public Dispatcher Dispatcher { get; set; }
      public QueuedEventLogger(Dispatcher dispatcher, Action<string> onLineLogged)
      {
        this.Dispatcher = dispatcher;
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
          using(var lineCollection = new BlockingCollection(queuedLines))
          {
            while(true)
            {
              string line = lineCollection.Take();
           
              if(onLineLogged == null)
                continue;
              if(this.Dispatcher == null)
                onLineLogged(line);
              else
                this.Dispatcher.Invoke(() => { onLineLogged(line); });
            }
          }
        });
      }
    }
