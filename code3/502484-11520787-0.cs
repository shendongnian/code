    public class RedirectRouteHandler : IRouteHandler
    {
    	private string _redirectUrl;
    
    	public RedirectRouteHandler(string redirectUrl)
    	{
    		_redirectUrl = redirectUrl;
    	}
    
    	public IHttpHandler GetHttpHandler(RequestContext requestContext)
    	{
    		if (_redirectUrl.StartsWith("~/"))
    		{
    			string virtualPath = _redirectUrl.Substring(2);
    			Route route = new Route(virtualPath, null);
    			var vpd = route.GetVirtualPath(requestContext,
    				requestContext.RouteData.Values);
    			if (vpd != null)
    			{
    				_redirectUrl = "~/" + vpd.VirtualPath;
    			}
    		}
    
    		return new RedirectHandler(_redirectUrl, false);
    	} 
    }
