    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect(ResolveClientUrl("~/login.aspx") + "?returnURL=" + HttpContext.Current.Request.Url.AbsolutePath);
        }
        else
        {
            lblUsername.Text = Session["Username"].ToString();
        }
    }
