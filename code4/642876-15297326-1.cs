    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        sampleDataTable();
        if (!Page.IsPostBack)
        {
            myGrid.DataSource = dt;
            myGrid.DataBind();
        }
    }
    private void sampleDataTable()
    {
        // Populate the dataTable
    }
