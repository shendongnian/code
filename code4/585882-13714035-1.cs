    public class HelloJob : IJob
    {
        private readonly ILog _log;
    
        public HelloJob(ILog log)
        {
            _log = log;
        }
        ...
    }
