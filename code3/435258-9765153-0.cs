    void btnLogin_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.IsInRole("Administrators"))
            Response.Redirect("~/PageA.aspx");
        else
            Response.Redirect("~/PageB.aspx");
    }
