    public static class HtmlExtensions
    {
        public static IHtmlString MyCustomHelperWhichShowButton(this HtmlHelper html, string text)
        {
            var isAuthnticated = html.ViewContext.HttpContext.User.Identity.IsAuthenticated;
            if (isAuthnticated)
            {
                return html.ActionLink(text, "MyListings", "List");
            }
    
            return new HtmlString(string.Empty);
        }
    }
