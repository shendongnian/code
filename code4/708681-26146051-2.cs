    namespace CustomHelpers
    {
        public static class CustomHelpers
        {
            public static MvcHtmlString Pluralize(this HtmlHelper htmlHelper,
                string source)
            {
                var serv = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));
                var plural = serv.Pluralize(source);
                return MvcHtmlString.Create(plural);
            }
        }
    }
