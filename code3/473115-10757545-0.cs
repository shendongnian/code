    private Label lblUrl;
    private TextBox txtUrl;
    private AssetUrlSelector picker;
    private Control control;
    protected override void CreateChildControls()
    {
        lblUrl = new Label();
        lblUrl.ID = "lblUrl";
        lblUrl.Text = "Url: ";
        Controls.Add(lblUrl);
        txtUrl = new TextBox();
        txtUrl.ID = "txtUrl";
        Controls.Add(txtUrl);
        picker = new AssetUrlSelector();
        picker.ID = "ausUrl";
        picker.DefaultOpenLocationUrl =  OpenUrl;
        picker.AssetUrlClientID = txtUrl.ClientID;
        picker.AssetUrlTextBoxVisible = false;
        Controls.Add(picker);
        control = Page.LoadControl(_ascxPath);
        Controls.Add(control);
    }
