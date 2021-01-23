    private static readonly ILog Log = LoggingFacility.GetLoggerWithInit(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
    /*** ... ***/
    public static class LoggingFacility
    {
      private static bool _loggerIsUp = false;
      public static ILog GetLoggerWithInit(Type declaringType)
      {
        if (_loggerIsUp == false)
          XmlConfigurator.Configure(_log4NetCfgFile);
        _loggerIsUp = true;
        return LogManager.GetLogger(declaringType);
      }
    }
