    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string GetServerTime()
    {
        return DateTime.Now.ToString();
    }
