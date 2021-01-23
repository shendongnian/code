    foreach (DataColumn col in tableFromDB.Columns)
    {
       dataGrid.Columns.Add(
         new DataGridTextColumn
         {
            Header = col.ColumnName,
            Binding = new Binding(string.Format("[{0}]", col.ColumnName))
         });
    }
    dataGrid.ItemsSource = tableFromDB.Rows;
    dataGrid.Items.Refresh();
