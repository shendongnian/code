    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadComboBox2.SelectedValue = Request.QueryString["value"];
        }
    }
