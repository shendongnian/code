    public class MyPage : System.Web.UI.Page
    {
        public static string Static1Url(string url)
        {
            return string.Format("{0}{1}", ConfigurationManager.AppSettings["Static1CDNUrl"], url);
        }
    }
