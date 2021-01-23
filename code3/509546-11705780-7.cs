    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/octet-stream";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + context.Request.QueryString["file"]);
        context.Response.WriteFile(context.Request.QueryString["file"]);
        context.Response.End();
    }
