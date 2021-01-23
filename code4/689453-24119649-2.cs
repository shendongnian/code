    protected void GridView10_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string cellt = e.Row.Cells[CORRECT CELL?].Text;
         if (cellt == "True")
        {
            Button btn = (Button)e.Row.Cells[CORRECT CELL?].Controls[1];
            btn.Enabled = false;
        }
    }
