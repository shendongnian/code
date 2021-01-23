    protected void ProductGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {            
        // Get the controls
        GridViewRow row = (GridViewRow)ProductGridView.Rows[e.RowIndex];
        TextBox tname = (TextBox)row.FindControl("txtName");
    
        // More code to populate product etc.
    }
