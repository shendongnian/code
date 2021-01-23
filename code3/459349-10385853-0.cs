    var firstRow = 2;
    var lastRow = 500000;
    var batchSize = 5000;
    var batches = Enumerable
        .Range(0, (int)Math.Ceiling( (lastRow-firstRow) / (double)batchSize ))
        .Select(x => 
            string.Format(
                "A{0}:AX{1}",
                x * batchSize + firstRow,
                Math.Min((x+1) * batchSize + firstRow - 1, lastRow)))
        .Select(range => ((Array)Globals.shData.Range[range]).Cells.Value);
    foreach(var batch in batches)
    {
        foreach(var item in batch)
        {
            //reencode item into your own object collection.
        }
    }
    
