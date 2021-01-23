    protected override void OnPreInit(EventArgs e)
    {
        if (this.Request.IsAuthenticated)
            this.Response.Redirect("~/Home.aspx");
        base.OnPreInit(e);
    }
