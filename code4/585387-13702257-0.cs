    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        string requestId = context.Request.QueryString["requestId"];
        string isPinned = context.Request.QueryString["isPinned"];
        var facade = new RequestManagementFacade();
        facade.PinRequest(Int32.Parse(requestId), Boolean.Parse(isPinned));
    }
