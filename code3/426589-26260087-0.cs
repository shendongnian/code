    public class WebApiApplication : System.Web.HttpApplication
    {
    	protected void Application_Start()
    	{
    		UnityConfig.RegisterComponents();
    		...
    	}
    }
