    public static class Logger
        {
            static Logger()
            {
                XmlConfigurator.Configure();
            }
    
            public static void Log()
            {
                string methodName = new System.Diagnostics.StackFrame(1, true).GetMethod().Name;
                string moduleName = new System.Diagnostics.StackFrame(1, true).GetMethod().ReflectedType.FullName;
    
                var appLog = LogManager.GetLogger(loggername);
    			appLog.Error(...);
    
            }
        }
