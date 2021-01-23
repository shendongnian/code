    for (int i = DataGridView1.SelectedRows.Count - 1; -1 < i; i--)
    {
       object objChecked = DataGridView1.SelectedRows[i].Cells[0].Value;
       if ((objChecked  != null) && !(bool)objChecked)
       {
         DataGridView1.Rows.RemoveAt(i);
       }
    }
