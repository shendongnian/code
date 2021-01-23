    public static class Log
    {
        private ILog log = new NullLogger();
        public static void Assign(ILog log)
        {
            this.log = log;
        }
        public static void Debug(string message)
        {
            log.Debug(message);
        }
        // ...and other implementations...
    }
