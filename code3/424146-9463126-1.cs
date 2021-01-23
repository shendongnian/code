    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new MyFilterAttribute());
    }
    protected void Application_Start()
    {
        // Other code removed for clarity of this example...
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
        // Other code removed for clarity of this example...
    }
