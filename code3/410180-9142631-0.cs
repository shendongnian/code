        public static void AddContentRoute(this RouteCollection routes, Data.UrlMap map, bool needsLock = false)
        {
            var route = new Route(map.Url, new MvcRouteHandler());
            route.Defaults = new RouteValueDictionary(new
            {
                controller = "Content",
                action = "Display",
                id = map.Id,
                type = map.Type
            });
            if (needsLock)
            {
                using (routes.GetWriteLock())
                {
                    routes.Insert(0, route);
                }
            }
            else
            {
                routes.Insert(0, route);
            }
        }
