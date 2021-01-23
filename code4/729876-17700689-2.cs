    public class LogGenerator
    {
        private readonly Log log;
        public LogGenerator(Log log)
        {
            this.log = log;
        }
        public void Foo()
        {
            ...
            this.log.WriteToLog("my log message");
        }
    }
