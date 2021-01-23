        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            RouteValueDictionary mergedRouteValues;
            if (RouteData == null)
            {
                mergedRouteValues = MergeRouteValues(actionName, controllerName, null, routeValues, includeImplicitMvcValues: true);
            }
            else
            {
                mergedRouteValues = MergeRouteValues(actionName, controllerName, RouteData.Values, routeValues, includeImplicitMvcValues: true);
            }
            //Only change here
            return new TicketRedirectResult(mergedRouteValues);
        }
