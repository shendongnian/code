    public sealed class LogManager : ILogger
    {
      #region Singleton
      static readonly LogManager instance = new LogManager();
      
      public static LogManager Current { return instance; }
      
      private LogManager() { } // Disallow creating instances.
      #endregion
      ILogger log;
      public void SetLog(ILogger log)
      {
        if(log == null)
          throw new ArgumentNullException("log");
        this.log = log;
      }
      public void Log(string line)
      {
        if(log != null)
          log.Log(line);
      }
      public void Log(string format, params object[] args)
      {
        if(log != null)
          log.Log(format, args);
      }
    }
