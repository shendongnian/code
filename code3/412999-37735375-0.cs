    namespace project.MvcHtmlHelpers
    {
        public static class HelperExtensions
        {
            public static MvcHtmlString RazorToMvcString(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
            {
                return MvcHtmlString.Create(template.Invoke(null).ToString());
            }
        }
    }
