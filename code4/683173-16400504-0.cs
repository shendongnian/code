    public static void Informational(string fmt, Exception exception)
    {
      LogEventInfo le = new LogEventInfo(LogLevel.Info, logger.Name, null, fmt, exception.ToString());
      logger.Log(typeof(LogWrapper), le);
    }
