    protected void Grid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		var data = (DataRowView)e.Row.DataItem;
    		var lbSector = (Label)e.Row.FindControl("lbSector");
    		var amount = (int)data("Amount");
    		var amountOverAll = (long)data.DataView.Table.Compute("SUM(Amount)", null);
    		if (amount * 100 / amountOverAll >= 30) {
    			lbSector.Text = data("Sector").ToString();
    		}
    	}
    }
