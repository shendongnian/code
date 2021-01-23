    namespace MvcHelpers.Helpers
    {
        public static class ButtonHelperExtension
        {
            public static MvcHtmlString SpecialButton(this HtmlHelper helper, string id)
            {
              return new MvcHtmlString(String.Format("<input id=\"{0}\" type=\"button\" value=\"Special\"/>", id));
            }
        }
    }
