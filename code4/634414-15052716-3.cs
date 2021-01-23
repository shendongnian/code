    public void ProcessRequest(HttpContext context)
    { 
        IEnumerable<EventInfo> result = ... fetch from db
        var serializer = new JavaScriptSerializer();
        context.Response.ContentType = "application/json";
        context.Response.Write(serializer.Serialize(result));
    }
