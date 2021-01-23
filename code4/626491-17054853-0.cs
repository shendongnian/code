    namespace MyDomain.Web.Helpers
    {
        public class BundleHelper
        {
            public static string CdnPath = "http://cdn.mydomain.com";
    
            public static IHtmlString RenderScript(string path)
            {
                var opt = System.Web.Optimization.Scripts.Render(path);
                string htmlString = HttpUtility.HtmlDecode(opt.ToHtmlString());
    
                if (BundleTable.EnableOptimizations)
                {
                    htmlString = htmlString.Replace("<script src=\"/", String.Format("<script src=\"{0}/", CdnPath));
                }
    
                return new HtmlString(htmlString);
            }
    
            public static IHtmlString RenderStyle(string path)
            {
                var opt = System.Web.Optimization.Styles.Render(path);
                string htmlString = HttpUtility.HtmlDecode(opt.ToHtmlString());
    
                if (BundleTable.EnableOptimizations)
                {
                    htmlString = htmlString.Replace("<link href=\"/", String.Format("<link href=\"{0}/", CdnPath));
                }
    
                return new HtmlString(htmlString);
            }
        }
    }
