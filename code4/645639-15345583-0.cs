    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Response.Cookies.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("~/LoginPage.aspx");
    }
