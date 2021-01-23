		private void DataGridRow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataGridRow row = sender as DataGridRow;
			if (row == null) return;
			if (row.IsEditing) return;
			if (!row.IsSelected) row.IsSelected = true; // you can't select a single cell in full row select mode, so instead we have to select the whole row
		}
		private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataGridCell cell = sender as DataGridCell;
			if (cell == null) return;
			if (cell.IsEditing) return;
			if (!cell.IsFocused) cell.Focus(); // you CAN focus on a single cell in full row select mode, and in fact you HAVE to if you want single click editing.
			//if (!cell.IsSelected) cell.IsSelected = true; --> can't do this with full row select.  You HAVE to do this for single cell selection mode.
		}
