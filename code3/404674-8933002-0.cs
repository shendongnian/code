    namespace System.Web.Mvc {
        public static class HtmlHelperExtensions {
            public static string Hyperlink(this HtmlHelper helper, string url, string linkText) {
                return String.Format("<a href='{0}'>{1}</a>", url, linkText);
            }
        }
    }
