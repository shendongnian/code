    protected void ProductGridView_RowUpdating(object sender, GridViewUpdateEventArgs e){
                Label lblName = (Label)ProductGridView.Rows[e.RowIndex].FindControl("lblName");
                TextBox txtName = (TextBox)ProductGridView.Rows[e.RowIndex].FindControl("txtName"));
                TextBox txtQuantity = (TextBox)ProductGridView.Rows[e.RowIndex].FindControl("txtQuantity"); 
                DropDownList ddlFamily = (DropDownList)ProductGridView.Rows[e.RowIndex].FindControl("ddlFamily"); 
    }
            
