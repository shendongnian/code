        public class Logger
        {
            public void Log(string message) { ... }
            private static Logger globalLogger;
            public static Logger GlobalLogger 
            {
                get
                {
                    if (globalLogger == null)
                    {
                        globalLogger = new Logger();
                    }
                    return globalLogger;
                }
            }
        }
