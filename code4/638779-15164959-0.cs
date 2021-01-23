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
            
        grid.Dump();
        horizontalWinners.Dump();
    }
