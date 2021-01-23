    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
          ddl1.DataSource = LocationofData;
          ddl1.DataBind();
          //first item in the list
          ddl1.Items.Insert(0, new ListItem("","-- Select--"));
       }
    }
