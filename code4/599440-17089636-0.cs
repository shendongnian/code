    public static class MyHelpers
    {
       
        public static IHtmlString PrintHelloWorld(this HtmlHelper helper)
        {
            return helper.Raw("Hello World");
        }
    }
