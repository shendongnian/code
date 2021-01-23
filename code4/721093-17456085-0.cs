    protected void Application_Error(object sender, EventArgs e)
    {
           // Your error handling stuff
           System.Web.HttpContext context = HttpContext.Current;
           System.Exception ex = context.Server.GetLastError();
           context.Server.ClearError();
           Response.Redirect("CustomError.aspx");
    }
