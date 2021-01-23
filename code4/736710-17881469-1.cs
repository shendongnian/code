     protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        //int id = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        TextBox tname = (TextBox)row.FindControl("nam");
       //to get value of first cell
        string str = row.Cells[0].Text.ToString();
     }
