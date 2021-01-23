    public static class TestHelper
        {
            public static HtmlString Test(this UrlHelper helper)
            {
                var ret = "/Test?par1=1&par2=2";
    
                var scriptTag = string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", ret);
    
                return new HtmlString(scriptTag);
            }
        }
