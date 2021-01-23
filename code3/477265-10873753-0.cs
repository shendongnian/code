	foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
	{
		foreach (DataGridViewCell cell in selectedCell.OwningRow.Cells)
		{
			if (cell.ColumnIndex > selectedCell.ColumnIndex)
				cell.Value = selectedCell.Value;
		}
	}
