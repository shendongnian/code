    protected void logout_OnClick(object sender, EventArgs e)
    {
    Session.Abandon();
    Response.Redirect("login.aspx");
    }
    
    protected void Page_Init(object sender, EventArgs e)
    {
    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.Cache.SetNoStore();
    }
