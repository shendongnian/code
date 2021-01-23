	protected void InitialiseController(T controller, NameValueCollection collection, params string[] routePaths)
	{
		Controller = controller;
		var routes = new RouteCollection();
		RouteConfig.RegisterRoutes(routes);
		var httpContext = ContextHelper.FakeHttpContext(RelativePath, AbsolutePath, routePaths);
		var context = new ControllerContext(new RequestContext(httpContext, new RouteData()), Controller);
		var urlHelper = new UrlHelper(new RequestContext(httpContext, new RouteData()), routes);
		Controller.ControllerContext = context;
		Controller.ValueProvider = new NameValueCollectionValueProvider(collection, CultureInfo.CurrentCulture);
		Controller.Url = urlHelper;
	}
