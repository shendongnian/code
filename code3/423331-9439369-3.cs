    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TimeSheetGrid.DataSource = GetData();
            TimeSheetGrid.DataBind();
        }
    }
