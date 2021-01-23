        using System.Windows.Controls;
        using System.Windows.Controls.Primitives;
        private void SetFocusOnNewRow(DataGrid theDataGrid, Int32 columnIndex)
        {
            theDataGrid.UnselectAll();
            theDataGrid.UpdateLayout();
            Int32 newRowIndex = theDataGrid.Items.Count - 1;
            theDataGrid.ScrollIntoView(theDataGrid.Items[newRowIndex]);
            DataGridRow newDataGridRow = theDataGrid.ItemContainerGenerator.ContainerFromIndex(newRowIndex) as DataGridRow;
            DataGridCellsPresenter newDataGridCellsPresenter = GetVisualChild<DataGridCellsPresenter>(newDataGridRow);
            if (newDataGridCellsPresenter != null)
            {
                DataGridCell newDataGridCell = newDataGridCellsPresenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
                if (newDataGridCell != null)
                    newDataGridCell.Focus();
            }
        }
        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
