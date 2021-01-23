    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    public class ConcurrentLogger : Logger, ILogger, IDisposable
    {
      bool isDisposed;
      BlockingCollection<string> loggedLines;
      Action<string> callback;
      public ConcurrentLogger(Action<string> callback)
      {
        if (callback == null)
          throw new ArgumentNullException("callback");
        var queue = new ConcurrentQueue<string>();
        this.loggedLines = new BlockingCollection<string>(queue);
        this.callback = callback;
        StartMonitoring();
      }
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool isDisposing)
      {
        if (isDisposed) return;
        if (isDisposing)
        {
          if (loggedLines != null)
            loggedLines.CompleteAdding();
        }
        isDisposed = true;
      }
      public override void Log(string line)
      {
        if (!loggedLines.IsAddingCompleted)
          loggedLines.Add(line);
      }
      protected virtual void StartMonitoring()
      {
        Task.Factory.StartNew(() =>
          {
            foreach (var line in loggedLines.GetConsumingEnumerable())
            {
              if (callback != null)
                callback(line);
            }
            loggedLines.Dispose();
          }, TaskCreationOptions.LongRunning);
      }
    }
