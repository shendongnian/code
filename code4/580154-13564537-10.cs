    protected void TestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Ignore the first row which is the header
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get hold of the row and then the DataRow that it's being bound to
            GridViewRow row = e.Row;
            DataRow data = ((DataRowView)row.DataItem).Row;
            // Look at the value and set the colour accordingly
            switch (data.Field<string>("Type"))
            {
                case "Assignment":
                    row.BackColor = System.Drawing.Color.FromName("Blue");
                    break;
                case "Exam":
                    row.BackColor = System.Drawing.Color.FromName("Red");
                    break;
            }
        }
    }
