    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     if (e.Row.RowType == DataControlRowType.DataRow)
     {
        // First check Checkedbox is check or not, In Cells insert you IsActive column index
        if( e.Row.Cells[1].Text == "False" )
            GridView1.BackColor = Color.Gray;
     }
    }
