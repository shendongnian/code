    protected void baseLogin1_LoggedIn(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated && Roles.IsUserInRole(Page.User.Identity.Name, "Admin"))
        {
            Page.Response.Redirect("admin/Default.aspx");
        }
    }
