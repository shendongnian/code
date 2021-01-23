    public static class Logger
    {
        public static void Log(Func<LoggerOptions, LoggerFinalOptions> options)
        {
            LoggerFinalOptions opts = options(new LoggerOptions());
            // do the logging, using properties/values from opts to guide you
        }
    }
