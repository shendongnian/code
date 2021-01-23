    protected void Page_Load(object sender, EventArgs e)
    {
        bool isAuthenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        Menu1.Visible = !isAuthenticated;
        NavigationMenu.Visible =isAuthenticated;
    }
