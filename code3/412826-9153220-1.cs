    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "Delete") {
    		int Case_ID = ((GridView)sender).DataKeys[e.CommandArgument].Values[0].ToString();
            // TODO, your delete routine
    	}
    }
