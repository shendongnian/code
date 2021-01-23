    public class LogEvent {
      public static readonly LogEvent SyncStart = new LogEvent(1, 
        "Sync Service started on {0}", TraceEventType.Start);
      public static readonly LogEvent SyncStop = new LogEvent(99, 
        "Sync Service stopped on {0}", TraceEventType.Stop);
      public static readonly LogEvent SyncError = new LogEvent(501, 
        "\r\n=============\r\n{0}\r\n==============\r\n", TraceEventType.Error);
      // etc
      private readonly int id;
      private readonly string format;
      private readonly TraceEventType type;
      private static readonly TraceSource trace = new TraceSource("SyncService");
      private LogEvent(int id, string format, TraceEventType type)
      {
        this.id = id;
        this.format = format;
        this.type = type;
      }
      public void Log(params object[] data)
      {
        var message = String.Format(format, data);
        trace.TraceEvent(type, id, message);
      }
    }
