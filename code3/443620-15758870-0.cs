        /// <summary>
        /// Get the cell of the datagrid.
        /// </summary>
        /// <param name="dataGrid">The data grid in question</param>
        /// <param name="cellInfo">The cell information for a row of that datagrid</param>
        /// <param name="cellIndex">The row index of the cell to find. </param>
        /// <returns>The cell or null</returns>
        private DataGridCell TryToFindGridCell(DataGrid dataGrid, DataGridCellInfo cellInfo, int cellIndex = -1)
        {
            DataGridRow row;
            DataGridCell result = null;
            if (dataGrid != null && cellInfo != null)
            {
                if (cellIndex < 0)
                {
                    row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(cellInfo.Item);
                }
                else
                {
                    row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(cellIndex);
                }
                if (row != null)
                {
                    int columnIndex = dataGrid.Columns.IndexOf(cellInfo.Column);
                    if (columnIndex > -1)
                    {
                        DataGridCellsPresenter presenter = this.FindVisualChild<DataGridCellsPresenter>(row);
                        if (presenter != null)
                        {
                            result = presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
                        }
                        else
                        {
                            result = null;
                        }
                    }
                }
            }
            return result;
        }`
