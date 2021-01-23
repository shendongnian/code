    public void SelectRow(DataGrid grid, int rowIndex)
        {
            grid.SelectedItem = null;
            object item = grid.Items[rowIndex];
            grid.SelectedItem = item;
            var row = grid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null)
            {
                grid.ScrollIntoView(item);
                row = grid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }
            if (row != null)
            {
                row.Focus();
                FocusManager.SetIsFocusScope(row, true);
                FocusManager.SetFocusedElement(row, row);
            }
        }
