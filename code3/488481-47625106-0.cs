    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Calculate()
    {
        HttpContext.Current.Request.InputStream.Position = 0;
        var jsonString = new StreamReader(HttpContext.Current.Request.InputStream, Encoding.UTF8).ReadToEnd();
        var json = JObject.Parse(jsonString);
        // your code
    }
