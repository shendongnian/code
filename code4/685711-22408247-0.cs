    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
    	DataTable _datatable = new DataTable();
    	for (int i = 0; i < grdReport.Columns.Count; i++)
    	{
    		_datatable.Columns.Add(grdReport.Columns[i].ToString());
    	}
    	foreach (GridViewRow row in grdReport.Rows)
    	{
    		DataRow dr = _datatable.NewRow();
    		for (int j = 0; j < grdReport.Columns.Count; j++)
    		{
    			if (!row.Cells[j].Text.Equals("&nbsp;"))
    				dr[grdReport.Columns[j].ToString()] = row.Cells[j].Text;
    		}
    
    		_datatable.Rows.Add(dr);
    	}
    	ExportDataTableToExcel(_datatable);
    }
