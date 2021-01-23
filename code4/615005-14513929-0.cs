    public static class LogManager
    {
        private static Lazy<MyLog> logLazy = new Lazy<MyLog>(() => new MyLog());
        public static MyLog Log
        {
            get{
                return logLazy.Value;
            }
        }
    }
