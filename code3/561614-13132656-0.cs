    public static MvcHtmlString GetPeriodLink(this HtmlHelper html, 
                                              RequestContext context, 
                                              DateTime date)
    {
        UrlHelper urlHelper = new UrlHelper(context);
        context.RouteData.Values.Remove("month");
        context.RouteData.Values.Remove("year");
        return MvcHtmlString.Create(
                  urlHelper.Action(
                     (string)context.RouteData.Values["action"], 
                     new { year = date.Year, month = date.Month }));
    }
