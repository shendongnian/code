    protected void assignnewminister_SelectedIndexChanged(object sender, EventArgs e)
    {
         //access the GridView
         GridView grid = (GridView) sender;
    
         //access the selected row
         GridViewRow selectedRow = grid.SelectedRow;
    
         //access the selected Primary key - make sure you set the DataKeyNames property of the GridView to the Record Id - in your Markup
         string currentRowPrimaryKey = grid.SelectedValue;
         //OR
         string currentRowPrimaryKey = grid.SelectedDataKey.Value;
    
    }
