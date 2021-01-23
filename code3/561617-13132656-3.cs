    public static MvcHtmlString GetPeriodLink(this HtmlHelper html, 
                                              RequestContext context, 
                                              DateTime date)
    {
        UrlHelper urlHelper = new UrlHelper(context);
        context.RouteData.Values["month"] = date.Month;
        context.RouteData.Values["year"] = date.Year;
        return MvcHtmlString.Create(
                  urlHelper.Action(
                     (string)context.RouteData.Values["action"]));
    }
