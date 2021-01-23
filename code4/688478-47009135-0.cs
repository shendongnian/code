    [HttpPost]
    public int PostPicture(HttpRequestMessage msg)
    {
        HttpContext context = HttpContext.ApplicationInstance.Context;
        proxy.ProcessRequest(context);
