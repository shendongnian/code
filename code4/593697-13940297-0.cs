	public class CustomRouteHandler : IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			string virtualPath = "~/path/to/page.aspx";
			
			int id;
			
			// this would obviously be some sort of database call
			if (requestContext.RouteData.Values["Name"] == "Paul") 
			{
				id = 2;
			}
			else
			{
				id = 8675309;
			}
			
			string newPath = string.Format(
				"{0}?id={1}",
				virtualPath,
				id
			);
			
			HttpContext.Current.RewritePath(newPath);
			return BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(Page)) as IHttpHandler;
		}
	}
