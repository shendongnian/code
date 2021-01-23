    private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
    {
        if(e.OriginalSource is DataGridCell)
            _currentCell = (DataGridCell) e.OriginalSource;
    }
    private void DataGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key == Key.C && (e.SystemKey == Key.LeftCtrl || e.SystemKey == Key.RightCtrl))
        {
             //Transform content here, like
             Clipboard.SetText(_currentCell.Content);
        }
    }
