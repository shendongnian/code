    protected void Page_Load(object sender, EventArgs e)
    {
      if(!isPostBack)
      {
          GridView1.DataSourceID = "SqlDataSource1";
          GridView1.DataBind();
      }
    }
      
