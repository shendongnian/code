    public static class PageHelper
    {
        public static HtmlHelper<object> GetPageHelper(this System.Web.WebPages.Html.HtmlHelper html)
        {
            return ((WebViewPage)WebPageContext.Current.Page).Html;
        }
        public static UrlHelper GetUrlHelper(this System.Web.WebPages.Html.HtmlHelper html)
        {
            return ((WebViewPage) WebPageContext.Current.Page).Url;
        }
    }
