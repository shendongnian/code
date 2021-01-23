    protected void Page_Load(object sender, System.EventArgs e)
    {
	if (!Page.IsPostBack) {
		GridViewTopics.DataSource = GetSomeSampleData();
		GridViewTopics.DataBind();
	}
    }
    private DataTable GetSomeSampleData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("Id");
        for (index = 1; index <= 10; index++) {
		    dynamic dr = dt.NewRow();
		    dr("Id") = index;
		    dr("Name") = "SomeName" + index.ToString();
		    dt.Rows.Add(dr);
	  }
	    return dt;
    }
    protected void GridViewTopics_RowEditing(object sender, GridViewEditEventArgs e)
    {
	GridViewTopics.DataSource = GetSomeSampleData();
	GridViewTopics.EditIndex = e.NewEditIndex;
	GridViewTopics.DataBind();
    }
