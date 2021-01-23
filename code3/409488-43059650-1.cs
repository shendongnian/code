    private void DataGridColumnHeader_OnClick(object sender, RoutedEventArgs e)
    {
        var columnHeader = sender as DataGridColumnHeader;
        if (columnHeader != null)
            {
            if (!Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                dataGrid.SelectedCells.Clear();
            }
            foreach (var item in dataGrid.Items)
            {
                dataGrid.SelectedCells.Add(new DataGridCellInfo(item, columnHeader.Column));
            }
        }
    }
