    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Menu1.Visible = false;
            NavigationMenu.Visible = true;
        }
        else
        {
            Menu1.Visible = true;
            NavigationMenu.Visible = false;
        }
    }
