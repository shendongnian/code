    protected void Page_Load(object sender, EventArgs e)
    {
        WebUserControl1 ctrl = (WebUserControl1)LoadControl("~/WebUserControl1.ascx");
        ctrl.ID = "controlId";
        UpdatePanel1.ContentTemplateContainer.Controls.Add(ctrl);
    }
