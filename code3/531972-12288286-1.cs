		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			DependencyResolver.SetResolver(new SpringDependencyResolver(ContextRegistry.GetContext()));
		}
