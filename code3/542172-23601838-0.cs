    public static bool Log(this ILog log, Level level, string message, Exception exception = null)
    {
        var logger = log.Logger;
        if (logger.IsEnabledFor(level))
        {
            logger.Log(logger.GetType(), level, message, exception);
            return true;
        }
        return false;
    }
    public static bool LogFormat(this ILog log, Level level, string messageFormat, params object[] messageArguments)
    {
        var logger = log.Logger;
        if (logger.IsEnabledFor(level))
        {
            var message = string.Format(messageFormat, messageArguments);
            logger.Log(logger.GetType(), level, message, exception: null);
            return true;
        }
        return false;
    }       
