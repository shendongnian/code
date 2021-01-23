    public static RouteBase Clone(this RouteBase route)
        {
            if (route.GetType() == typeof(Route))
                return ((Route)route).Clone();
            else
                return null;
        }
        public static Route Clone(this Route route)
        {
            Route cloneRoute = new Route(route.Url, route.RouteHandler);
            cloneRoute.Defaults = route.Defaults;
            cloneRoute.Constraints = route.Constraints;
            return cloneRoute;
        }
