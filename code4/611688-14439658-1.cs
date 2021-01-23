    IUnityContainer container = new UnityContainer();
    container.Register<ILogger,SomeLoggerImplementation>();
    container.Register<Foo>();
    container.Register<Bar>();
    //will create a new instance of SomeLoggerImplementation using a default ctor, pass it to the constructor of Foo and return the instance of Foo
    //if SomeLoggerImplementation has some other dependancies they can be registered in the container too! 
    var foo = container.Resolve<Foo>();
    //will create a new instance of SomeLoggerImplementation using a default ctor, create a new instance of Bar, 
    //Set the value of the Property Logger (but not the Logger2), and return the instance of Bar
    var bar = container.Resolve<Bar>();
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
        
        //this will not be injected
        public ILogger Logger2 { get; set; }
        public Bar()
        {
        }
    }
