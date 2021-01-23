    if (!Page.IsPostBack && !ajxUploadNDA.IsInFileUploadPostBack)
    {
      Session.Remove("DefaultDocumentCategory");
      lblDocumentCategory.Text = "Data Package Files";
      Session.Remove("DefaultDocumentTitle");
      lblDocumentTitle.Text = "Data Package File";
    }
    protected void btnChangeDocumentAttributes_Click(object sender, EventArgs e)
    {
        lblDocumentCategory.Text = cboDocumentCategory.SelectedValue;
        lblDocumentTitle.Text = txtDocumentTitle.Text;
        Session["DefaultDocumentCategory"] = lblDocumentCategory.Text;
        Session["DefaultDocumentTitle"] = lblDocumentTitle.Text;
    }
