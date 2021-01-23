    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CurrencyFormat(this HtmlHelper helper, string value)
        {
            var result = string.Format("{0:C2}", value);
            return new MvcHtmlString(result);
        }
    }
