    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string key = "123456";
            hdnField.Value = key;
        }
    }
