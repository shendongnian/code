    public static class LoggerExtensions
    {
        public static void Debug( this ILogger logger, string format, params object[] args)
        {
            logger.Log( new LogEntry( typeof(LoggerExtensions), LogLevel.Debug, format, args ) );
        }
    
        ...
    }
