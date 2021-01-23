    [TestClass]
    public class MyTestClass
    {
    	private static TestContext _testContext;
    	
    	[ClassInitialize]
    	public static void TestFixtureSetup(TestContext context)
    	{
    		_testContext = context;
    	}
    	
        [TestInitialize]
        public void TestIntialize()
        {
            string testMethodName = MyTestClass._testContext.TestName;
    		switch (testMethodName)
    		{
    			case "TestMethodA":
    			
    				//todo..
    				
    				break;
    			case "TestMethodB":
    			
    				//todo..
    				
    				break;				
    			default:
    				break;
    		}
        }
    
        [TestMethod]
        public void TestMethodA()
        {
        }
    	
        [TestMethod]
        public void TestMethodB()
        {
        }	
    }
