        public static string GenerateUrl(string routeName, string actionName, string controllerName, RouteCollection routeCollection, RequestContext requestContext)
        {
            RouteValueDictionary mergedRouteValues = MergeRouteValues(actionName, controllerName);
            VirtualPathData vpd = routeCollection.GetVirtualPathForArea(requestContext, routeName, mergedRouteValues);
            if (vpd == null)
            {
                return null;
            }
            string modifiedUrl = PathHelpers.GenerateClientUrl(requestContext.HttpContext, vpd.VirtualPath);
            return modifiedUrl;
        }
        public static RouteValueDictionary MergeRouteValues(string actionName, string controllerName)
        {
            // Create a new dictionary containing implicit and auto-generated values
            RouteValueDictionary mergedRouteValues = new RouteValueDictionary();
            // Merge explicit parameters when not null
            if (actionName != null)
            {
                mergedRouteValues["action"] = actionName;
            }
            if (controllerName != null)
            {
                mergedRouteValues["controller"] = controllerName;
            }
            return mergedRouteValues;
        }
