    protected void Application_EndRequest(object sender, EventArgs e)
    {
         var entityContext = HttpContext.Current.Items["myContext"] as MyDbContext;
         if (entityContext != null)
             entityContext.Dispose();
    }
