        protected void Application_Start()
        {
            //help page
            AreaRegistration.RegisterAllAreas();
            
            //api
            BreezeWebApiConfig.RegisterBreezePreStart();
            
            //hot towel
            HotTowelRouteConfig.RegisterHotTowelPreStart();
            //register bundles
            HotTowelConfig.PreStart();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
