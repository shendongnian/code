    protected void Page_Load(object sender, EventArgs e)
    {
    	DataTable dt = new DataTable();
    	dt.Columns.Add("C1");
    	dt.Columns.Add("C2");
    	dt.Columns.Add("C3");
    	dt.Columns.Add("C4");
    	dt.Columns.Add("C5");
    	dt.Columns.Add("C6");
    	dt.Columns.Add("C7");
    	dt.Columns.Add("C8");
    	dt.Columns.Add("C9");
    	dt.Columns.Add("C10");
    	DataRow drRow;
    	for (int i = 0; i < 10; i++)
    	{
    		drRow = dt.NewRow();
    		drRow[0] = "C10000000" + i;
    		drRow[1] = "C20000000" + i;
    		drRow[2] = "C30000000" + i;
    		drRow[3] = "C40000000" + i;
    		drRow[4] = "C50000000" + i;
    		drRow[5] = "C60000000" + i;
    		drRow[6] = "C70000000" + i;
    		drRow[7] = "C80000000" + i;
    		drRow[8] = "C90000000" + i;
    		drRow[9] = "C100000000" + i;
    		dt.Rows.Add(drRow);
    	}
    	GridView1.DataSource = dt;
    	GridView1.DataBind();
    	GridView1.Rows[9].Cells[0].ID = "footerCell";
    	GridView1.Rows[9].Attributes.Add("class", "frozenFooter");
    }
     
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	e.Row.Cells[0].CssClass = "frozenCell";
    }
