    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
    
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    
        // Register custom model validators
        DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ValidateEmailAttribute), typeof(EmailValidator));
    }
