    protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
    
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                AuthConfig.RegisterAuth();
                Bootstrapper.Initialise();
                ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory));
            } 
