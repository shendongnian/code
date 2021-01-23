    protected void Page_Load(object sender, EventArgs e)
    {
      ....
      if (!IsPostBack)
      {
        rgTable.DataSource = arrTables;
        rgTable.DataBind();
      }
    }
