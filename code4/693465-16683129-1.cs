    var j = 0;
    while (j++ < 40)
    {
    	var k = 0;
    	var emptyRow = new TableRow();
    	while (k++ < 3)
    	{
    		var emptyCell = new TableCell();
    		emptyCell.Text = "|empty Cell|";
    		emptyRow.Cells.Add(emptyCell);
    	}
    	Table1.Rows.Add(emptyRow);
    }
