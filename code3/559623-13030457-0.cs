    public static class MyUtility
    {
       
     public static string GetAppPath()
        {
            return (System.Web.HttpRuntime.AppDomainAppVirtualPath == "/") ? string.Empty : System.Web.HttpRuntime.AppDomainAppVirtualPath;
        }
    }
