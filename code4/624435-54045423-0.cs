    	private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (dataGrid.SelectedItem is DataRowView view)
			{
				DataRow currentRow = view.Row;
				DataTable table = currentRow.Table;
				dataAdapter.Fill(table.Rows.IndexOf(currentRow), 1, table);
			}
		}
