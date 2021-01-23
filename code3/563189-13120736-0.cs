    if (e.ColumnIndex != 3)
				return;
			int nextRowIndex = e.RowIndex - 1;
			int lastRowIndex = SecondaryGridView.Rows.Count;
			try{
				if (nextRowIndex <= lastRowIndex)
				{
					var value = SecondaryGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
					SecondaryGridView.Rows[nextRowIndex].Cells[2].Value = value;
				}
			}
			catch(Exception exception){}
