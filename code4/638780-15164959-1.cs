    void Main()
    {
        // Quickish and very dirty way to generate the grid
        var lineLength = 3;
        var rnd = new Random();
        var gridSrc = 
            from r in Enumerable.Range(0, lineLength)
            from c in Enumerable.Range(0, lineLength)
            select new { Row = r, Col = c, Text = rnd.Next(0,2) > 0 ? "X" : "O" };
        var grid = gridSrc.ToArray();
        
        // ok, now for the query
        var horizontalWinners =
            // need the cell and it's index - this is one way to do that
            from cellTuple in grid.Select((cell, idx) => Tuple.Create(idx, cell))
            let idx = cellTuple.Item1
            let cell = cellTuple.Item2
            // figure out which row its in
            let row = idx / lineLength
            // figure out which column its in
            let col = idx % lineLength
            // for rows, group by row #
            group cell by row into byRow
            // only count if all cells in that row are same
            where byRow.All(rowCell => rowCell.Text == "X") 
                 || byRow.All(rowCell => rowCell.Text == "O")
            // tell us what row (and who won)
            select new { byRow.Key, byRow.First().Text };
            
	var verticalWinners =
		from cellTuple in grid.Select((cell, idx) => Tuple.Create(idx, cell))
		let idx = cellTuple.Item1
		let cell = cellTuple.Item2
		let row = idx / lineLength
		let col = idx % lineLength
		group cell by col into byCol
		where byCol.All(colCell => colCell.Text == "X") 
                     || byCol.All(colCell => colCell.Text == "O")
		select new { byCol.Key, byCol.First().Text };
	var topLeftBottomRightDiagonalWinners =
		from cellTuple in grid.Select((cell, idx) => Tuple.Create(idx, cell))
		let idx = cellTuple.Item1
		let cell = cellTuple.Item2
		let row = idx / lineLength
		let col = idx % lineLength
		let fwdSlash = (row == col)
		group cell by fwdSlash into byDiag
		where byDiag.Key && byDiag.All(d => d.Text == byDiag.First().Text)
		select new { 
                     Text = byDiag.First().Text, 
                     Pos = string.Join("", byDiag.Select(c => Tuple.Create(c.Col, c.Row).ToString())) 
                };
	var topRightBottomLeftDiagonalWinners =
		from cellTuple in grid.Select((cell, idx) => Tuple.Create(idx, cell))
		let idx = cellTuple.Item1
		let cell = cellTuple.Item2
		let row = idx / lineLength
		let col = idx % lineLength
		let backSlash = (row + col) == (lineLength - 1)
		group cell by backSlash into byDiag		
		where byDiag.Key && byDiag.All(d => d.Text == byDiag.First().Text)
		select new { 
                   Text = byDiag.First().Text, 
                   Pos = string.Join("", byDiag.Select(c => Tuple.Create(c.Col, c.Row).ToString())) 
                };
	for(int r=0;r<lineLength;r++)
	{
		for(int c=0;c<lineLength;c++)
		{
			Console.Write(grid[r*lineLength+c].Text + " ");
		}
		Console.WriteLine();
	}
	foreach(var row in horizontalWinners)
	{
		Console.WriteLine("{0} wins on row {1}", row.Text, row.Key);
	}
	foreach(var col in verticalWinners)
	{
		Console.WriteLine("{0} wins on col {1}", col.Text, col.Key);
	}
	foreach (var diag in topLeftBottomRightDiagonalWinners
                    .Concat(topRightBottomLeftDiagonalWinners))	
	{
		Console.WriteLine("{0} wins on diagonal {1}", diag.Text, diag.Pos);		
	}
    }
