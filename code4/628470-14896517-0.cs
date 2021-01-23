    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string city="";
        if (e.CommandName == "btnname")
        {
            ImageButton imgbtn = (ImageButton)e.CommandSource;
            GridViewRow rows = (GridViewRow)imgbtn.NamingContainer;
            city = grid.Rows[rows.RowIndex].Cells[1].Text;           
        }
    }
