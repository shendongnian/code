     var rows= GetDataGridRows(nameofyordatagrid); 
    foreach (DataGridRow r in rows)  
      {  
        DataRowView rv = (DataRowView)r.Item;
        foreach (DataGridColumn column in nameofyordatagrid.Columns)
        {
            if (column.GetCellContent(r) is TextBlock)
            {
                TextBlock cellContent = column.GetCellContent(r) as TextBlock;
                MessageBox.Show(cellContent.Text);
            }
      } 
