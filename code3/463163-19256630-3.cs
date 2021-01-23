    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder c = Page.Master.FindControl("ScriptsPlace") as ContentPlaceHolder;
        HtmlGenericCOntrol jsDiv = this.FindControl("_jsDiv") as HtmlGenericControl;
        if (c != null && jsDiv != null)
        {
            c.Controls.Add(jsDiv);
        }
    }
