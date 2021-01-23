    public abstract class Browser
    {
    	public List<URL> URL { public get; private set; }
    
    	protected Browser
    	{
    		URL = new List<URL>();
    	}
    }
    
    public class InternetExplorer : Browser
    {
    	
    
    }
    
    public class Chrome : Browser
    {
    	
    
    }
