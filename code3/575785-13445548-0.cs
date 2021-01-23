    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!Page.IsPostBack)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataKeyNames = new String[] {"UserId"};
            GridView1.DataBind();
        }
    }
