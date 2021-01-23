	foreach (DataGridViewRow row in dataGridView1.Rows)
	{
		foreach (DataGridViewCell cell in row.Cells)
		{
			DataGridViewCell neighbour = FindCell(new Point(cell.ColumnIndex, row.Index), cell.Value.ToString());
			//	Found
			if (neighbour != null)
			{
				DataGridViewCell emptyCell = FindCell(new Point(cell.ColumnIndex, row.Index), string.Empty);
				if (emptyCell != null)
				{
					emptyCell.Value = "WHATEVERYOUREQUIREITTOBE";
				}
			}
		}
	}
