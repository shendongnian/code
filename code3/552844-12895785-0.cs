    int row = cellAddress.Start.Row;
    int column = cellAddress.Start.Column;
    
    
    if (mCellsResult.Count() > 0)
    {
    var mCells = mCellsResult.First();
    
    //if the cell and the merged cell do not share a common start address then skip this cell as it's already been covered by a previous item
    if (mCells.Start.Address != cellAddress.Start.Address)
                                                            continue;
    
    if (mCells.Start.Column != mCells.End.Column)
    {
    colSpan += mCells.End.Column - mCells.Start.Column;
    }
    
    if (mCells.Start.Row != mCells.End.Row)
    {
       rowSpan += mCells.End.Row - mCells.Start.Row;
    }
    }
    double height = 0, width = 0;
    for (int h = 0; h < rowSpan; h++)
    {
    height += xlWorkSeet1[k].Row(row + h).Height;
    }
    for (int w = 0; w < colSpan; w++)
    {
     width += xlWorkSeet1[k].Column(column + w).Width;
    }
    
    double pointToPixel = 0.75;
    
    height /= pointToPixel;
    width /= 0.1423;
    
    
    picture = xlWorkSeet1[k].Drawings.AddPicture(System.Guid.NewGuid().ToString() + row.ToString() + column.ToString(), image);
    picture.From.Column = column - 1;
    picture.From.Row = row - 1;
    picture.SetSize((int)width, (int)height);
