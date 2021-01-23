    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString W(this HtmlHelper htmlHelper, string message)
        {
            return VCBox.Helpers.Localization.w(message);
        }
    }
