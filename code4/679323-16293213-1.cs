    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
          GridView1.DataSourceID = "SqlDataSource1";
          GridView1.DataBind();
      }
    }
      
