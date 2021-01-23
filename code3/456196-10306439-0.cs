    public interface ILogUtility<T> where T : class
    {
         void Log(LogType logtype, string message);
    }
    public class Log4NetUtil<T> : ILogUtility<T> where T : class
    {
        log4net.ILog log;
    
        public LogUtil()
        {
            log = log4net.LogManager.GetLogger(typeof(T).FullName);
        }
    
        public void Log(LogType logtype, string message)
        {
            Console.WriteLine("logging coming from class {0} - message {1} " , typeof(T).FullName, message);
        }
    }
