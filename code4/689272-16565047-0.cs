    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
       gv.EditIndex = e.NewEditIndex;
       BindGridView();//You have  to  Bind GridView Again Here...
    }
