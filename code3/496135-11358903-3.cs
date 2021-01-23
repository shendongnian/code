    protected void RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if the ViewMe command is fired
    	if (e.CommandName == "ViewMe")
    	{
            // go to find the index on the grid view
    		int iTheIndexNow;
    		if (int.TryParse(e.CommandArgument.ToString(), out iTheIndexNow))
    		{
                // Set and highlight the selected
    			TheGridView.SelectedIndex = iTheIndexNow;
    
                // do we have the table data id ?
    			if (TheGridView.SelectedValue != null)
    			{
    				// now load the controls data using this id
    				LoadValuesFromDatabaseToControls(TheGridView.SelectedValue);
    			}    
    		}
    	}
    }
