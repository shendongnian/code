    public class SessionCollection
    {
      public static String DynamicJavaScript
      {
        get
        {
           return Convert.ToString(HttpContext.Current.Session["DynamicJavaScript"]);
        }
        set
        {
           System.Web.HttpContext.Current.Session["DynamicJavaScript"] = value;
        }
      }
    }
