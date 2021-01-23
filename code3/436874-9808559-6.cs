    public class ClassDependentOnLogger
    {
        private ILogger _logger;  
        public ClassDependentOnLogger(ILogger logger)
        {
            _logger = logger;
        }
        ....
    }
