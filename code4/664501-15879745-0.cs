    public class Foo
    {
    	private object sync = new object();
    	public void Bar()
    	{
    		lock (this.sync)
    		{
    			// You can call new Foo().Bar() multiple times, because
    			// each Foo class lock its own instance of the sync object
    		}
    	}
    }
    
    public class Foo
    {
    	private static object sync = new object();
    	public void Bar()
    	{
    		lock (sync)
    		{
    			// You can't call new Foo().Bar() multiple times, because
    			// each Foo class lock the same instance of the sync object
    		}
    	}
    }
