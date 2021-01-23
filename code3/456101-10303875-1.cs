    class LogUtil<T> : ILogUtility
    {
        log4net.ILog log;
    
        public LogUtil<T>()
        {
            log = log4net.LogManager.GetLogger(typeof(T));
        }
    
        public void Log(LogType logtype, string message)
        {
            Console.WriteLine("logging coming from class {0} - message {1} " , typeof(T).FullName, message);
        }
    
        public static LogUtil<NewType> Create<NewType>(NewType instance)
        {
          return new LogUtil<NewType>();
        }
    }
    
    public class TestCode
    {
        public void test()
        {
            var logutil = LogUtil.Create(this);
        }
    }
