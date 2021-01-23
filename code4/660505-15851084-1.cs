    public class WebContextFactory : IContextFactory
    {
    	public HttpContext GetContext()
    	{
    		return HttpContext.Current;
    	}
    }
