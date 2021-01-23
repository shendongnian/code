	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.MapRoute(
			"Default" // Route name
			, "{controller}/{action}/{id}" // URL with parameters
			, new { area = "management", controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			, new[] { "Portal.Web.Areas.Management.Controllers" } // Namespace of controllers in root area
		);
	}	
