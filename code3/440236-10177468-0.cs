    double newHeight = cellsPresenter.ActualHeight + e.VerticalChange;     
    DataGridRowHeader rowHeader = GetFirstVisualChild<DataGridRowHeader>(row);    
    if (rowHeader != null)    
    { 
        // clamp the CellsPresenter size to the MaxHeight of Row, 
        // because row wouldn't grow any larger
        double maxHeight = row.MaxHeight;
        if (newHeight > maxHeight)
        {
            newHeight = maxHeight;
        }
    }
    cellsPresenter.Height = newHeight;
    // Updating row's height doesn't work correctly; shows weird behavior    
    // row.Height = newHeight >= 0 ? newHeight : 0;
