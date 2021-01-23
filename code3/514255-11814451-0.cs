    class LoggingController {
 
        private ILogger _logger
        
        // expecting an interface here removes the dependency 
        // to a specific implemenentation.
        // all it cares about is that the object has a Log() method
        public LoggingController(ILogger logger) {
            _logger = logger;
        }
        public void Log() { _logger.Log(); }
    }
    interface ILogger { 
        void Log(); 
    }
    class DbLogger : ILogger { 
        public void Log(){ //log into db }
    }
    class TxtLogger : ILogger {
        public void Log(){ //log into a txt file }
    }
