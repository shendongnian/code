    GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        // you only want to check DataRow type, and not headers, footers etc.
    	if (e.Row.RowType == DataControlRowType.DataRow) {
                // you already know you're looking at this row, so check your cell text
    		if (e.Row.Cells(1).Text == "C6N") {
    			e.Row.BackColor = System.Drawing.Color.Red;
    		}
    	}
    }
