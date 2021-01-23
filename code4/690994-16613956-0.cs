    using System.Web;
    [WebMethod]
    public static string GetLogs()
    {        
        string resource = HttpContext.Current.Server.MapPath("Resource.xml");
    }
