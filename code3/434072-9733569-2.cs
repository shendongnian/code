    protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
    	if(e.CommandName=="Add")
    	{
          int index = Convert.ToInt32(e.CommandArgument);
	      GridViewRow row = ContactsGridView.Rows[index];
    	  //What ever code you want to do....
    	}
    } 
    //Set the command argument to the row index
    protected void GridView1_RowCreated(Object sender, GridViewRowEventArgs e)
    {
    	if(e.Row.RowType == DataControlRowType.DataRow)
    	{
    	  LinkButton addButton = (LinkButton)e.Row.Cells[0].Controls[0];
    	  addButton.CommandArgument = e.Row.RowIndex.ToString();
    	}
    }
