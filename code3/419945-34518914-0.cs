    public class LogReader
    {
        ILogger _logger;
        public LogReader(ILogger logger)
        {
            _logger = logger;
        }
        public LogEntity GetLog()
        {
            Task<LogEntity> task = Task.Run<LogEntity>(async () => await GetLogAsync());
            return task.Result;
        }
        public async Task<LogEntity> GetLogAsync()
        {
            var result = await _logger.GetAsync();
            // more code here...
            return result as LogEntity;
        }
    }
