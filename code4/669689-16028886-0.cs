    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
       GridView1.EditIndex = e.NewEditIndex;
             
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
       e.Cancel = true;
       GridView1.EditIndex = -1;
             
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       GridViewRow row = GridView1.Rows[e.RowIndex];
      
       TextBox txtProductName = (TextBox)row.FindControl("txtProductName");
       TextBox txtUnitPrice = (TextBox)row.FindControl("txtUnitPrice");
    
       //From here you can fire Update query on database.
      
    }
