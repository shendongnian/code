    protected void ProductGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProductGridView.EditIndex = e.NewEditIndex;
            ProductGridView.DataBind();
        }       
    
    protected void ProductGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {            
        // Get the controls
    
        GridViewRow row = ProductGridView.Rows[e.RowIndex];
        Label lblName = (row.FindControl("lblName") as Label); // Returns this label, from the row being edited, just fine
        TextBox txtName = (row.FindControl("txtName") as TextBox); // null
        TextBox txtQuantity = (row.FindControl("txtQuantity") as TextBox); // null
        DropDownList ddlFamily = (row.FindControl("ddlFamily") as DropDownList); // null
    
        // More code to populate product etc.
    }
