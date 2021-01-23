    // In the login page
    void Page_Load()
    {
        if (User.Identity.IsAuthenticated)
               Response.Redirect("~/Default.aspx");
    }
