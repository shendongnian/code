    foreach (DataGridRow rowContainer  in GetDataGridRows(gridname))
    {
      if (rowContainer != null)
      {
         DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
         DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
         if (cell == null)
         {
            dataGrid1.ScrollIntoView(rowContainer, dataGrid1.Columns[column]);
            cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
          }
          //start work with cell
      }
    }
