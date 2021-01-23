    public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.svc/{*pathInfo}");
			routes.MapRoute(
				"CustomFunctions", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new
				{
					controller = "CustomFunctions",
					action = "Index",
					id = UrlParameter.Optional
				}, // Parameter defaults
				new { controller = "^(?!CustomFunctions).*" }
			);
			routes.Add(new ServiceRoute("CustomFunctions", new ServiceHostFactory(),
					   typeof(CustomFunctions)));
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");			
			// Had to do some special stuff here to get this to work using a default area and no controllers/view in the root
            routes.MapRoute(
                name: "Default",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new { area = "", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Viper.Areas.Home" }
            ).DataTokens.Add("area", "Home");			
		}
