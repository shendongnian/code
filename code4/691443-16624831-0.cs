    public static class IoC
    {
    	public static readonly IUnityContainer Container;
    	
    	static IoC()
    	{
    		IUnityContainer container = new UnityContainer();
    		container.RegisterType<ISomeInterface, SomeClass>();
    		Container = container;
    	}
    }
