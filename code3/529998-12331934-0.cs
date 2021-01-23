    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 1; i < GridView2.Columns.Count; i++)
            {
                String header = GridView2.Columns[i].HeaderText; 
                if (header.Length != 0)
                {
                   e.Row.Cells[i+1].ToolTip = ListBox4.Items[i].ToString().Trim();
                }
            }
        }
    }
