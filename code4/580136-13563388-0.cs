    public static string ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName, object routeValues)
        {
        //Your code ...
        string url = urlHelper.Action(actionName, routeValues);
        }
