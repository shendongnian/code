    public void ProcessRequest(HttpContext context)
    {
            context.Response.Write("<H1>This is an HttpHandler Test.</H1>");      
            context.Response.Redirect("YourPage.aspx");
    }
