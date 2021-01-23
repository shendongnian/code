    public void Page_Load(object sender, EventArgs e){
       if(!IsPostBack)
        {
           MinistryDropdown.DataSource = CreateDataSource();
           MinistryDropdown.DataTextField = "Description";
           MinistryDropdown.DataValueField = "Description";
           MinistryDropdown.DataBind();
    
          ...other code here...
       }
    }
