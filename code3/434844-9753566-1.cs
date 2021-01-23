    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod()]
    public static bool CheckSession()
    { 
        return (Session["ASP.NET_SessionId"] == null)
    }
