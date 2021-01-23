    protected void TestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Ignore the first row which is the header
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get hold of the row and then the DataRow that it's being bound to
            GridViewRow row = e.Row;
            DataRow data = ((DataRowView)row.DataItem).Row;
            row.BackColor = System.Drawing.Color.FromName(data.Field<string>("BackColour");
            row.ForeColor = System.Drawing.Color.FromName(data.Field<string>("TextColour");
        }
    }
