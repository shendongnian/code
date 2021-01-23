    public static class SearchHelper
    {
        public static MvcHtmlString SearchResult(this HtmlHelper helper,
            IEntity entity)
        {
            return new MvcHtmlString("A normal thing");
        }
        public static MvcHtmlString SearchResult(this HtmlHelper helper,
            IPhoto photo)
        {
            return new MvcHtmlString("A photo!");
        }
    }
