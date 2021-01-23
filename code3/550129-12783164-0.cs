    public void ProcessRequest (HttpContext context) 
    {
        ....
        context.Response.AppendHeader("Content-Type", "video/mp4");`
        context.Response.AppendHeader("Accept-Ranges", "bytes");
        .....
    }
