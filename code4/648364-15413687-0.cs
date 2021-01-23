    public class Foo
    {
        private ILogger _logger;
    
        public Foo(ILogger logger)
        {
             _logger = logger;
        }
    
        public void Bar()
        {
           _logger.Write("Bar is called");
           // do something
        }
    }
