    public static class TestExtensions
    {
        public static string Foo(this HtmlHelper html, Func<object, HelperResult> func)
        {
            return func(null).ToHtmlString();
        }
        public static string MyStringExtension(this string s)
        {
            return s.ToUpper();
        }
    }
