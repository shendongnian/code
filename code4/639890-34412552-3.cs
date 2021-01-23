    private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (grid.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                int index = grid.SelectedIndex;
                if (index >= 0)
                {
                    var row = grid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                    if (row != null)
                    {
                        row.Focus();
                        var presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(0);
                        cell.Focus();
                        FocusManager.SetIsFocusScope(row, true);
                        FocusManager.SetFocusedElement(cell, cell);
                    }
                        
                }
            }
        }
