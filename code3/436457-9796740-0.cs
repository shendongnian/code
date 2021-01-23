    public interface ILogger
    {
        void Log(string message);
    }
    public class Foo
    {
        private ILogger _logger;
        public Foo (ILogger logger)
        {
            _logger = logger;
        }
        public void DoWork ()
        {
            _logger.Log("Working...");
        }
    }
