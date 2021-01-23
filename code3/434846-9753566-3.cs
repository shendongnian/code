    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod()]
    public static bool CheckSession()
    { 
        //this can also include logic to check if session is close to expiring
        return (Session["ASP.NET_SessionId"] == null)
    }
