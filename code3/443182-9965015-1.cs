    // In the login page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
               Response.Redirect("~/Default.aspx");
    }
