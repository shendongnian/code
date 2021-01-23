    The code looked like this:
    [Binding]
    public class MySpecFlowContext
    {    
    ...
    	[BeforeFeature]
    	private static void InitializeObjectFactories()
    	{
    		ObjectFactory.Initialize(x =>
    		{
    			x.AddRegistry<StoreRegistry>();
    			x.AddRegistry<CommonRegistry>();
    		});
    	}   
    }
