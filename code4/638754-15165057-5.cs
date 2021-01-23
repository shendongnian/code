    public static void RegisterRoutes(RouteCollection routes)
	{
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		RouteTable.Routes.Add(new ServiceRoute("SVC/My", new WebServiceHostFactory(), typeof(MyService)));
	}
