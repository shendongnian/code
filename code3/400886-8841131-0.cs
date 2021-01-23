    public static class MyHtmlHelpers
    {
        public static MyHelpers SubGroup(this HtmlHelper helper)
        {
            return new MyHelpers(helper);
        }
    }
    public class MyHelpers
    {
        public HtmlHelper Helper { get; private set; }
        public MyHelpers(HtmlHelper helper)
        {
            this.Helper = helper;
        }
        public MvcHtmlString MyCustomHelper(string someArgument)
        {
            return MvcHtmlString.Create(someArgument);
        }
    }
