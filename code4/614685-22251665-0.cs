    private void MyGrid_SelectAll(object sender, ExecutedRoutedEventArgs e)
		{
			var myGrid = (DataGrid)sender;
			myGrid.Focus();
			if (myGrid.SelectedCells.Count == myGrid.Columns.Count * myGrid.Items.Count)
			{
				myGrid.SelectedCells.Clear();
			}
			else
			{
				myGrid.SelectAll();
			}
			e.Handled = true;
		}
