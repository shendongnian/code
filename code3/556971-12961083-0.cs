    private void gvGroupPlans_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	DataRowView drv = null;
    
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		drv = (DataRowView)e.Row.DataItem();
    
    		e.Row.Cells[1].Text = (DateTime.Parse(dr("col5").ToString())).ToString("d");
    	}
    }
