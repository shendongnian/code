    public static class Logger
    {
        public static void Log(Func<LoggerOptions, LoggerOptions> options)
        {
            LoggerOptions opts = options(new LoggerOptions());
            // do the logging, using properties/values from opts to guide you
        }
    }
