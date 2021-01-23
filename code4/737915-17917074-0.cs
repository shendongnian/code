    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDown.DataSourceID = Sections;
            DropDown.DataTextField == "DisplayName";
            DropDown.DataValueField = "ID"; 
            DropDown.DataBind();           
        }
    }
