        private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    var cell = GetCell(dgIssuance, dgIssuance.Items.Count - 1, 2);
                    if (cell != null)
                    {
                        cell.IsSelected = true;
                        cell.Focus();
                        dg.BeginEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message, "Error", MessageType.Error);
            }
        }
   
    public static DataGridCell GetCell(DataGrid dg, int row, int column)
        {
            var rowContainer = GetRow(dg, row);
            if (rowContainer != null)
            {
                var presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter != null)
                {
                    // try to get the cell but it may possibly be virtualized
                    var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    if (cell == null)
                    {
                        // now try to bring into view and retreive the cell
                        dg.ScrollIntoView(rowContainer, dg.Columns[column]);
                        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    }
                    return cell;
                }
            }
            return null;
        }
