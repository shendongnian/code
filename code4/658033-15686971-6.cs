    var rows = GetDataGridRows(nameofyordatagrid); 
    foreach (DataGridRow row in rows)  
    {  
      DataRowView rowView = (DataRowView)row.Item;
      foreach (DataGridColumn column in nameofyordatagrid.Columns)
      {
          if (column.GetCellContent(row) is TextBlock)
          {
              TextBlock cellContent = column.GetCellContent(row) as TextBlock;
              MessageBox.Show(cellContent.Text);
          }
      } 
