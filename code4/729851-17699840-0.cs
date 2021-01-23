    public class MyClass
    {
    	static readonly string config;
    	
    	static MyClass()
    	{
    		try
    		{
    			config = File.ReadAllText("config.ini");
    		}
    		catch (FileNotFoundException)
    		{
    			//do something else
    			//use a default configuration?
    			//report to the user?
    			//crash and burn?
    		}
    	}
    }
