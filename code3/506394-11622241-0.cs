    private void MyDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int columnsCount = this.Columns.Count;
            int selectedCells = SelectedCells.Count;
            int selectedItems = SelectedItems.Count;
            if (selectedCells > 1)
            {
                if (selectedItems == 0 || selectedCells % selectedItems != 0)
                {
                    DataGridCellInfo cellInfo = SelectedCells[0];
                    SelectedCells.Clear();
                    SelectedCells.Add(cellInfo);
                    CurrentCell = SelectedCells[0];
                }
            }
        }
