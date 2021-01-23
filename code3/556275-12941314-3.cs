    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        myDDL.DataSource = myDataTable;
        myDDL.DataBind();
      }
    }
