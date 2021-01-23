    public StarBuildParams()
    {
        this.BaseNo = Int32.Parse(Request.QueryString["BaseNo"].ToString());
        this.Width = Int32.Parse(Request.QueryString["Width"].ToString());
    }
