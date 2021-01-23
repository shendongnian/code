    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {    
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string name     = row.Cells[1].Text;
        string subname  = row.Cells[2].Text;
    }
