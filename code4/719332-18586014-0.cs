    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Test()
    {
       System.Web.HttpContext.Current.Response.Write(ToJson("Hello World"));
    }
