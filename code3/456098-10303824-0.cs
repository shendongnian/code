    class LogUtil : ILogUtility
    {
        Type _classtype;
        log4net.ILog log;
    
        public LogUtil(Type classtype)
        {
            _classtype = classtype;
            log = log4net.LogManager.GetLogger(_classtype.FullName);
        }
    
        public void Log(LogType logtype, string message)
        {
            Console.WriteLine("logging coming from class {0} - message {1} " , _classtype.FullName, message);
        }
    }
