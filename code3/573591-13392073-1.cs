    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["LoggedIn"] != null)
        {
            LinkButton1.Visible = true;
        }
    }
