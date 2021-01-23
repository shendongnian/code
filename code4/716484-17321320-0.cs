    protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox check = (CheckBox)e.Row.FindControl("CheckBox1");
            CheckBox check2 = (CheckBox)e.Row.FindControl("CheckBox2");
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            int accesType = row.Field<int>("AccessType");
            check.Checked = accesType == 1;
            check2.Checked = accesType == 2;
        }
    }
