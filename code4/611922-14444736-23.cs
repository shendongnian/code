    public sealed class LogManager : ILogger
    {
      #region Singleton
      static readonly LogManager instance = new LogManager();
      public static LogManager Current { get { return instance; } }
      private LogManager() { } // Disallow creating instances.
      #endregion
      ILogger logger;
      public ILogger Logger { get { return logger; } }
      public void StartLogging(ILogger logger)
      {
        if (logger == null)
          throw new ArgumentNullException("logger");
        this.logger = logger;
      }
      public void StopLogging(bool dispose = true)
      {
        var previousLogger = this.logger as IDisposable;
        this.logger =null;
        if (previousLogger != null && dispose)
          previousLogger.Dispose();
      }
      public void Log(string line)
      {
        if (logger != null) logger.Log(line);
      }
      public void Log(string format, params object[] args)
      {
        if (logger != null) logger.Log(format, args);
      }
    }
