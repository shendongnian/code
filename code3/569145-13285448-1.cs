    public static string getApplicationName()
    {
        return string.IsNullOrEmpty(HttpRuntime.AppDomainAppId)?
            Assembly.GetEntryAssembly().GetName().Name : 
            new DirectoryInfo(HttpContext.Current.Server.MapPath("")).Name;
    }
