       private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderStyle = null;
            dataGrid.AutoGeneratingColumn -= DataGrid_AutoGeneratingColumn;
        }
 
