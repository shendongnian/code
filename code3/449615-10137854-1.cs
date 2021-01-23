    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes(RouteTable.Routes);
      //Here you tell how to hendle the specific type 
      ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
    }
