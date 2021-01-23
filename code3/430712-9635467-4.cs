	/// <summary>
	/// List of locations around given location. Add to previous value to get next location.
	/// </summary>
	Point[] neighbours = new Point[]
	{
		new Point (-1, -1),
		new Point (1, 0),
		new Point (1, 0),
		new Point (-2, 1),
		new Point (2, 0),
		new Point (-2, 1),
		new Point (1, 0),
		new Point (1, 0),
	};
	/// <summary>
	/// Finds a cell containing given string value.
	/// </summary>
	/// <param name="location">Point of search</param>
	/// <param name="value">Value to find</param>
	/// <returns>Cell containing given value</returns>
	DataGridViewCell FindCell(Point location, string value)
	{
		for (int i = 0; i < neighbours.Length; ++i)
		{
			//	Move location to new point
			location.Offset(neighbours[i]);
			//	Check boundaries
			if (location.Y >= 0 && location.Y < dataGridView1.RowCount
				&& location.X >= 0 && location.X < dataGridView1.Columns.Count)
			{
				//	Get cell 
				DataGridViewCell cell = dataGridView1.Rows[location.Y].Cells[location.X];
				//	If value matches
				if ((cell.Value ?? string.Empty).ToString() == value)
				{
					return cell;
				}
			}
		}
		//	No match
		return null;
	}
