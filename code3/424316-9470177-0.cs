    int row = myGrid.Row;
    
    // Perform update
    
    try
    {
        vJanusDataGridMeasures.Row = row;
    }
    // The row index that was selected no longer exists.
    // You could avoid this error by checking this first.
    catch (IndexOutOfRangeException)
    {
        // Check to see if there are any rows and if there are select the first one
        if(vJanusDataGridMeasures.GetRows().Any())
        {
            vJanusDataGridMeasures.Row = 0;
        }
    }
