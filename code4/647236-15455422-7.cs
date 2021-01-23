    public static class RouteCollectionExtensions
    {
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "This is not a regular URL as it may contain special routing characters.")]
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url)
        {
            return MapLowercaseRoute(routes, name, url, null /* defaults */, (object)null /* constraints */);
        }
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "This is not a regular URL as it may contain special routing characters.")]
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapLowercaseRoute(routes, name, url, defaults, (object)null /* constraints */);
        }
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "This is not a regular URL as it may contain special routing characters.")]
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return MapLowercaseRoute(routes, name, url, defaults, constraints, null /* namespaces */);
        }
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "This is not a regular URL as it may contain special routing characters.")]
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return MapLowercaseRoute(routes, name, url, null /* defaults */, null /* constraints */, namespaces);
        }
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "This is not a regular URL as it may contain special routing characters.")]
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return MapLowercaseRoute(routes, name, url, defaults, null /* constraints */, namespaces);
        }
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "2#", Justification = "This is not a regular URL as it may contain special routing characters.")]
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            Route route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = CreateRouteValueDictionary(defaults),
                Constraints = CreateRouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }
            routes.Add(name, route);
            return route;
        }
        private static RouteValueDictionary CreateRouteValueDictionary(object values)
        {
            var dictionary = values as IDictionary<string, object>;
            if (dictionary != null)
            {
                return new RouteValueDictionary(dictionary);
            }
            return new RouteValueDictionary(values);
        }
    }
