    public static MvcHtmlString MenuRouteLink(this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues,
        IDictionary<string, object> htmlAttributes)
    {
        string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
        string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
    
        var route = RouteTable.Routes[routeName] as Route;
        if (route != null)
        {
            routeValues = routeValues ?? new RouteValueDictionary();
            string routeAction = (routeValues["action"] as string ?? route.Defaults["action"] as string) ?? string.Empty;
            string routeController = (routeValues["controller"] as string ?? route.Defaults["controller"] as string) ?? string.Empty;
    
            if (routeAction.Equals(currentAction, StringComparison.OrdinalIgnoreCase) && routeController.Equals(currentController, StringComparison.OrdinalIgnoreCase))
            {
                htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();
                var currentCssClass = htmlAttributes["class"] as string ?? string.Empty;
                htmlAttributes["class"] = string.Concat(currentCssClass, currentCssClass.Length > 0 ? " " : string.Empty, "active");
            }
        }
    
        return htmlHelper.RouteLink(linkText, routeName, routeValues, htmlAttributes);
    }
