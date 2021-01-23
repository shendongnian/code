    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (this.Session["master"] != null)
        {
            this.MasterPageFile = string.Format("~/{0}.master", (string)this.Session["master"]);
        }
    }
