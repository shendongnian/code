    protected void baseLogin1_LoggedIn(object sender, EventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated && Context.User.IsInRole("Admin"))
        {
            Context.Response.Redirect("admin/Default.aspx");
        }
    }
