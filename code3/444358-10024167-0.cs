    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		// loop all data rows
    		foreach (DataControlFieldCell cell in e.Row.Cells) {
    			// check all cells in one row
    			foreach (Control control in cell.Controls) {
    				// Must use LinkButton here instead of ImageButton
    				// if you are having Links (not images) as the command button.
    				ImageButton button = control as ImageButton;
    				if (button != null && button.CommandName == "Delete") {
    					// Add delete confirmation
    					button.OnClientClick = "if (!confirm('Are You Sure to Delete this Vehicle ?')) return;";
    				}
    			}
    		}
    	}
    }
