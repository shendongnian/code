	StringBuilder sb = new StringBuilder();
	foreach(TableRow row in Table1.Rows)
	{
		foreach (TableCell cell in row.Cells)
		{
			  //adding separator
			  sb.Append(cell.Text + ',');
		}
		//appending new line
		sb.Append("\r\n");
	}
