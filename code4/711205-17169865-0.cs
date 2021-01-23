    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx"); //redirect to main page
        }
    }
