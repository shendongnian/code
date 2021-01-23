    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            bool isActive = row.Field<int>("Fld_status") == 1;
            Label lbl_status = (Label) e.Row.FindControl("lbl_status");
            lbl_status.Text = isActive ? "active" : "inactive"; 
        }
    }
