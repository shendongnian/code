    public interface ILog 
    {
        void WriteToLog(string message);
    }
    public class Log : ILog
    {
        public void WriteToLog(string message)
        {
            ...
        }
    }
    public class LogGenerator
    {
        private readonly ILog log;
        public LogGenerator(ILog log)
        {
            this.log = log;
        }
        public void Foo()
        {
            ...
            this.log.WriteToLog("my log message");
        }
    }
