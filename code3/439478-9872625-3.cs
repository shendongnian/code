    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow && 
        (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
       {
           DropDownList DropDownList1= (DropDownList)e.Row.FindControl("DropDownList1");
           DropDownList1.SelectedValue = "No";
       }
    }
