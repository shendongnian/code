    public static class Logger
        {
            private static readonly Object obj = new Object();
    
            private static ILog _appLog = null;
            static Logger()
            {
                XmlConfigurator.Configure();
            }
    
            public static void Log()
            {
                string methodName = new System.Diagnostics.StackFrame(1, true).GetMethod().Name;
                string moduleName = new System.Diagnostics.StackFrame(1, true).GetMethod().ReflectedType.FullName;
    
                lock (obj)
                {
                    _appLog = LogManager.GetLogger(loggername);
    			}
    			
    			_appLog.Error(...);
    
            }
        }
