    public static class CustomRouteExtensions
    {
        public static Route MapRoute(this RouteCollection routes, string name, string url, string excludeRouteValueNames, object defaults)
        {
            return MapRoute(routes, name, url, excludeRouteValueNames, defaults, null, null);
        }
        public static Route MapRoute(this RouteCollection routes, string name, string url, string excludeRouteValueNames, object defaults, string[] namespaces)
        {
            return MapRoute(routes, name, url, excludeRouteValueNames, defaults, null, namespaces);
        }
        public static Route MapRoute(this RouteCollection routes, string name, string url, string excludeRouteValueNames, object defaults, object constraints)
        {
            return MapRoute(routes, name, url, excludeRouteValueNames, defaults, constraints, null);
        }
        public static Route MapRoute(this RouteCollection routes, string name, string url, string excludeRouteValueNames, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (url == null)
                throw new ArgumentNullException("url");
            Route item = new CustomRoute(url, new MvcRouteHandler(), excludeRouteValueNames)
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if ((namespaces != null) && (namespaces.Length > 0))
                item.DataTokens["Namespaces"] = namespaces;
            routes.Add(name, item);
            return item;
        }
    }
