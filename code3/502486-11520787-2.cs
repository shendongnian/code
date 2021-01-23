    public static class RouteExtensions
    {
    	public static void Redirect(this RouteCollection routes, string url, string redirectUrl)
    	{
    		routes.Add(new Route(url, new RedirectRouteHandler(redirectUrl)));
    	}
    }
