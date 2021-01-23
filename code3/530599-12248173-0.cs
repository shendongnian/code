    public void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView gv = (GridView)sender;
        GridViewRow row = gv.Rows[e.RowIndex];
        // assuming its ID is "DropDownList1"
        DropDownList ddl = (DropDownList)row.FindControl("DropDownList1"); 
        String selectedValue = ddl.SelectedValue;
