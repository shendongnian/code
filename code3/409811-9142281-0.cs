        void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.asxd/{*pathInfo}");
            routes.Add(
                new Route(
                    "{locale}/{*url}", //Route Path
                    null, //Default Route Values
                    new RouteValueDictionary{{"locale", "[a-z]{2}"}}, //constraint to say the locale must be 2 letters. You could also use something like "en-us|en-gn|ru" to specify a full list of languages
                     new Utility.Handlers.DefaultRouteHandeler() //Instance of a class to handle the routing
                ));
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
        }
