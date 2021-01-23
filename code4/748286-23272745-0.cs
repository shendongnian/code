    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer == null || string.IsNullOrEmpty(Request.UrlReferrer.AbsolutePath))
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
