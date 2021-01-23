    foreach(GridViewRow row in GridView2.Rows)
    {
        for(int i = 0; i < GridView2.Columns.Count, i++)
        {
            String header = GridView2.Columns[i].HeaderText;
            String cellText = row.Cells[i].Text;
        }
    }
