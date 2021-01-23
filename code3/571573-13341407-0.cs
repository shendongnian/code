    protected void gridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            foreach (DataColumn col in row.Table.Columns)
            {
                if (col.DataType == typeof(DateTime))
                { 
                    DateTime dt = row.Field<DateTime>(col);
                    e.Row.Cells[col.Ordinal].Text = dt.ToString("D");
                }
            }
        }
    }
