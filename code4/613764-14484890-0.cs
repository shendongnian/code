    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _logger;
    
        public Log4NetAdapter(ILog logger)
        {
            _logger = logger;
        }
    
        ...
    }
