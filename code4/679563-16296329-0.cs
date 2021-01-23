    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = lblPackTitle.Text;
        System.Web.UI.HtmlControls.HtmlMeta metaTagKey = new System.Web.UI.HtmlControls.HtmlMeta();
        metaTagKey.Name = "Keywords";
        metaTagKey.Content = "This is my keyword text";
        this.Header.Controls.Add(metaTagKey);
        System.Web.UI.HtmlControls.HtmlMeta metaTagDesc = new System.Web.UI.HtmlControls.HtmlMeta();
        metaTagDesc.Name = "description";
        metaTagDesc.Content = "This is my description text";
        this.Header.Controls.Add(metaTagDesc);
        //----------------------------Added here-----------------------------
        Control ctrlKeyMeta = this.Header.FindControl("key");
        Control ctrlDescMeta = this.Header.FindControl("desc");
        ctrlKeyMeta.Visible = false;
        ctrlDescMeta.Visible = false;
    }
