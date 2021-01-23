    protected void Page_Load(object sender, EventArgs e)
    {
        Type type = BuildManager.GetCompiledType("~/Default.aspx");
        var page = (Default)Activator.CreateInstance(type);
        ((IHttpHandler)page).ProcessRequest(HttpContext.Current);
        var count = page.Controls.Count;
        Response.Clear(); // Because we use HttpContext.Current the response has a lot of stuff
    }
