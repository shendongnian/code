    public void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string bookname = ((TextBox)(gv_table1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
                             // OR
        string bookname =(gv_table1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text;
        gv_table1.EditIndex = -1;  // reset the edit index
        // Again Bind the gridview to show updated data
    }
