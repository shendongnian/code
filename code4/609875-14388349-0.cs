    public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
    {
        if (row != null)
        {
            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
    
            if (presenter == null)
            {
                grid.ScrollIntoView(row, grid.Columns[column]);
                presenter = GetVisualChild<DataGridCellsPresenter>(row);
            }
    
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
            return cell;
        }
        return null;
    }
