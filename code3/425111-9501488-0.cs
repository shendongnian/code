    public class NLogLogger : ILogger
    {
      public NLogLogger(Logger logger, NLogFactory factory)
      {
        Logger = logger;
        Factory = factory;
      }
    
      internal NLogLogger() {}
    
      public bool IsDebugEnabled
      {
        get { return Logger.IsDebugEnabled; }
      }
      public void Debug(string message)
      {
        Logger.Debug(message);
      }
    }
