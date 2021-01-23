    The working code looks like this:
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
    			x.AddRegistry<RegistryOverrideForTest>();
    		});
    	}    
	
    	class RegistryOverrideForTest : Registry
    	{
    		public RegistryOverrideForTest()
    		{
    			 //NOTE: type of scope is needed when overriding the registered classes/interfaces, when leaving it empty the scope will be what was registered originally, f ex "HybridHttpOrThreadLocalScoped" in my case. 
    			For<DataContext>()
    				.Transient()
    				.Use<DataContext>()
    				.Ctor<string>("connection").Is(ConnectionBuilder.GetConnectionString());
    		}
    	}
    }
