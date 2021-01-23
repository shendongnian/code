    internal static class DllMain
    {
    	private volatile bool Initialized = false;
    	
    	public static void OnStaticConstructor()
    	{
    		if (!Initialized)
    		{
    			Initialized = true;
    			Initialize();
    		}
    	}
    	
    	private void Initialize()
    	{
    		// Put whatever you need to run once here.
    	}
    }
    
    public class A
    {
    	static A()
    	{
    		DllMain.OnStaticConstructor();
    	}
    	
    	// ...
    }
    
    public class B
    {
    	static B()
    	{
    		DllMain.OnStaticConstructor();
    	}
    	
    	// ...
    }
