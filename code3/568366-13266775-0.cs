     private void dataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridCell gridCell = null;
            try
            {
                gridCell = GetCell(dataGrid1.SelectedCells[0]);
            }
            catch (Exception)
            {
            }
            if (gridCell != null)
                gridCell.Background = Brushes.Red;
           
        }
    public  DataGridCell GetCell(DataGridCellInfo dataGridCellInfo)
        {
            if (!dataGridCellInfo.IsValid)
            {
                return null;
            }
            var cellContent = dataGridCellInfo.Column.GetCellContent(dataGridCellInfo.Item);
            if (cellContent != null)
            {
                return (DataGridCell)cellContent.Parent;
            }
            else
            {
                return null;
            }
        }
    private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            e.Row.MouseEnter += (s, args) => Row_MouseEnter(s, grid);
            e.Row.MouseLeave += (s, args) => Row_MouseLeave(s, grid);
        }
        void Row_MouseLeave(object sender, DataGrid grid)
        {
            DataGridRow row = sender as DataGridRow;
            grid.SelectedIndex = -1;
        }
        void Row_MouseEnter(object sender, DataGrid grid)
        {
            DataGridRow row = sender as DataGridRow;
            grid.SelectedIndex = row.GetIndex();
        }
