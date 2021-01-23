    public static class RedirectToRouteResultExtensions
    {
        private static IDictionary<RedirectToRouteResult, bool> typeRoute;
        public static RedirectToRouteResult SetRouteRequested(this RedirectToRouteResult redirectToRouteResult, bool value)
        {
            if (typeRoute == null)
            {
                typeRoute = new Dictionary<RedirectToRouteResult, bool>();
            }
            typeRoute[redirectToRouteResult] = value;
            return redirectToRouteResult;
        }
        public static bool IsRouteRequested(this RedirectToRouteResult redirectToRouteResult)
        {
            if (typeRoute == null)
            {
                return false;
            }
            return typeRoute.ContainsKey(redirectToRouteResult)
                        ? typeRoute[redirectToRouteResult]
                        : false;
        }
    }
