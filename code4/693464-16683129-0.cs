    for (int i = 0; i < 40; i++)
    {
    	var emptyRow = new TableRow();
    
    	for (int j = 0; j < 3; j++)
    	{
    		var emptyCell = new TableCell();
    		emptyCell.Text = "|empty Cell|";
    		emptyRow.Cells.Add(emptyCell);
    	}
    
    	Table1.Rows.Add(emptyRow);
    }
