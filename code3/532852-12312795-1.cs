    namespace YourMvcApplication.WebUI.HtmlHelpers
    {
        public static class PagingHelpers
        {
            public static MvcHtmlString PageLinks(this HtmlHelper html,int totalPages)
            {
                StringBuilder result = new StringBuilder();
                // do the complex logic to create dynamic html and append to 
                // String Builder
                return MvcHtmlString.Create(result.ToString());
            }
        }
    }
