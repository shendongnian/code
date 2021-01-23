    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
    {
        if (string.IsNullOrEmpty(linkText))
        {
            throw new ArgumentException(MvcResources.Common_NullOrEmpty, "linkText");
        }
        return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, routeValues, htmlAttributes));
    }
 
