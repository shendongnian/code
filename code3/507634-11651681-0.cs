    [TestFixture]
    public class FooBase
    {
    	[Test]
    	public void GetBarIsNotNullTest()
    	{
    		var foo = IoC.Current.Resolve<IFoo>();
    		Bar actual = foo.GetBar();
    		Assert.IsNotNull(actual);   
    	}
    	
    	//many other tests	
    }
