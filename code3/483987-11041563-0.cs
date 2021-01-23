    [TestFixture]
        class DomainTests
        {
            protected static readonly ILog log = LogManager.GetLogger(typeof(DomainTests));
            public void LoggingTests()
            {            
                log4net.Config.XmlConfigurator.Configure(); 
            }
    
            [Test]
            public void BasicLogTest()
            {
                log.Error("write my log entry already");
            }
            [SetUp]
    	    RunBeforeAnyTests()
    	    {
                BasicConfigurator.Configure();
    	    }
    
            [TearDown]
    	    RunAfterAnyTests()
    	    {
    	      // ...
    	    }
