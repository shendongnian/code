    DataGridRow gridRow = dgInventory.ItemContainerGenerator.ContainerFromIndex(row) as DataGridRow;
    
    if (gridRow != null)
    {
        DataGridCell cell = dgInventory.Columns[column].GetCellContent(gridRow).Parent as DataGridCell;
    
        cell.BorderBrush = Brushes.Red;
        cell.IsEditing = true;
        dgInventory.IsReadOnly = false;
    
        cell.ToolTip = tooltip;
    }
