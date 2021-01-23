    //Constructor injection
    public class Foo
    {
        private ILogger _logger;
        public Foo(ILogger logger)
        {
            //if Foo is resolved from the container , the value for the logger parameter will be provided from the container
            _logger = logger;
        }
    }
    //property injection
    public class Bar
    {
        //If Bar is resolvced from the container the value for the Logger property will also  be provided from the container
        [Dependency]
        public ILogger Logger { get; set; }
        public Bar()
        {
        }
    }
