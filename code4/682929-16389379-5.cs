    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !Request.IsAuthenticated)
        {
            Response.Redirect("~/tools/default.aspx");
        }
    }
