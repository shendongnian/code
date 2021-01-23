    protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // this will only change the rows backgound not the column header 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].BackColor = System.Drawing.Color.LightCyan; //first col
            e.Row.Cells[1].BackColor = System.Drawing.Color.Black; // second col
        }
    }
