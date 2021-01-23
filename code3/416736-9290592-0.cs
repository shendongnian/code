    private object changedRow;
        private void MainDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            changedRow = e.Row.Item;
        }
        private void MainDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (changedRow != null)
            {
                // do something with the edited row here
                changedRow = null;
            }
        }
