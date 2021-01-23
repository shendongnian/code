    private void DataGridMeterValues_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
    {
    
    FrameworkElement element = e.Column.GetCellContent(datagrid.SelectedItem);
    StackPanel panel = element as StackPanel;
    panel.Background = Colors.Red/Yellow watever color you like. 
    
    }
