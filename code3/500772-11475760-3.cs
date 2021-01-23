    protected void Application_Start()
    {
    	AreaRegistration.RegisterAllAreas();
    	ModelBinders.Binders.Add(typeof(SearchData), new SearchDataModelBinder());
    	RegisterGlobalFilters(GlobalFilters.Filters);
    	RegisterRoutes(RouteTable.Routes);
    
    	MvcHandler.DisableMvcResponseHeader = true;
    }
