    public static class RouteExtensions
    {
        public static Route MyMapRoute(this RouteCollection routes, string name, string url, object defaults)
        {
            var defaultValues = new RouteValueDictionary(defaults);
            if (!defaultValues.ContainsKey("action"))
            {
                defaultValues["action"] = "index";
            }
            var route = new Route(url, new MvcRouteHandler())
            {
                Defaults =  defaultValues,
                Constraints = new RouteValueDictionary(),
                DataTokens = new RouteValueDictionary()
            };
            routes.Add(name, route);
            return route;
        }
    }
