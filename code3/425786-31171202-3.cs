    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
            Response.End();
        }
        else
        {
            //All other Page_Load logic
        }
    }
    
