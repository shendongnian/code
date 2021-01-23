    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            String name = row.Field<String>("name");
            // String is a reference type, so you just need to compare with null
            if(name != null){/* do something */}
        }
    }
