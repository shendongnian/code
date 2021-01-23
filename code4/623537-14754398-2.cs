    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var rbSelect = (RadioButton)e.Row.FindControl("rbSelect");
            var row = ((DataRowView)e.Row.DataItem).Row;
            rbSelect.Checked = row.Field<bool>("Select");
        }
    }
