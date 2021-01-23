    private void OnCellFormatting(object sender,
       DataGridViewCellFormattingEventArgs e)
    {
    
        if (e.ColumnIndex == grid.Columns["Unbound"].Index)
        {
           e.FormattingApplied = true;
           DataGridViewRow row = grid.Rows[e.RowIndex];
           e.Value = string.Format("{0} : {1}",
              row.Cells["SomeColumn1"].Value,
              row.Cells["SomeColumn2"].Value);
        }
    }
    
    private void OnRowsAdded(object sender,
       DataGridViewRowsAddedEventArgs e)
    {
    
       for (int i = 0; i < e.RowCount; i++)
       {
          DataGridViewRow row = grid.Rows[e.RowIndex + i];
          row.Cells["Unbound"].Value = string.Format("{0} : {1}",
             row.Cells["SomeColumn1"].Value,
             row.Cells["SomeColumn2"].Value);
        }
    }
