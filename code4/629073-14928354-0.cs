        //-----------------------------------------------------------------------------------
        // Name:        RegisterRoutes
        // Purpose:     Register the routes for the site.
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("admin/errorlog.axd/{*pathInfo}");
            routes.MapRoute(
                "Base", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Base", action = "Main", id = UrlParameter.Optional }  // Parameter defaults
            );
        }
        //-----------------------------------------------------------------------------------
        // Name:        Application_Start
        // Purpose:     The application start event handler.
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            InitSquishIt();
        }
