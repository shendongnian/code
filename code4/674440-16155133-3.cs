    if ((0 < DataGridView1.Rows.Count) && (0 < DataGridView1.Columns.Count)) 
    {
      for (int i = DataGridView1.Rows.Count - 1; -1 < i; i--)
      {
        var row = DataGridView1.Rows[i];
        if ((row.Cells[0].Value != null) && (row.Cells[0].Value != DBNull.Value))
        {
          bool isChecked = (bool)row.Cells[0].Value;
          if (isChecked)
          {
            DataGridView1.Rows.Remove(row);
          }
        }
      }
    }
