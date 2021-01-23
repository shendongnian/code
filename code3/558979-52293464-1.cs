    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (string.Compare(e.Row.Cells[i].Text, "Date", true) == 0)
                {
                    e.Row.Cells[i].Text = "Created Date";
                }
            }
        }
    }
