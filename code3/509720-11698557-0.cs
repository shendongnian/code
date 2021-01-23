    for (int i = 0; i < table.Rows.Count; i++)
    { 
       ListViewItem row = new ListViewItem(table.Rows[i][0].ToString());
       for (int j = 1; j < table.Columns.Count; j++)
       {
          row.SubItems.Add(table.Rows[i][j].ToString());
       }
       lstDisplay.Items.Add(row);
    }
