    [TestFixture]
    public class UnitTestFoo : FooBase
    {
    	[SetUp]
    	public void SetUp()
    	{
    		IoC.Current.Register<IFoo, FakeFoo>();		  
    	}
    	
    	//nothing else here
    }
    
    [TestFixture]
    public class IntegrationTestFoo : FooBase
    {
    	[SetUp]
    	public void SetUp()
    	{
    		IoC.Current.Register<IFoo, RealFoo>();		  
    	}
    	
    	//nothing else here
    }
