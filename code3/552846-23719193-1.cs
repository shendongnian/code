    /// <summary>Get top, left, width and height of a given cell.</summary>
        Rectangle GetCellTopLeftCoordinates(ExcelWorksheet worksheet, ExcelRangeBase cell)
        {
            double top = 0, left = 0, width = 0, height = 0;
                
            //Get top and left position:
            for (int i = 1; i < cell.Start.Row; i++)
                top += worksheet.Row(i).Height;
            for (int i = 1; i < cell.Start.Column; i++)
                left += worksheet.Column(i).Width;
            
            //Get width and height:
            if (cell.Merge)  //Then the cell are merged with others:
            {
                foreach (string address in worksheet.MergedCells)  //Loop through all merged cells:
                    if (Intersect(worksheet.Cells[address], cell))  //Then we have found the particular, merged range:
                    {
                        ExcelRange range = worksheet.SelectedRange[address];
                        for (int i = range.Start.Row; i <= range.End.Row; i++)
                            height += worksheet.Row(i).Height;
                        for (int i = range.Start.Column; i <= range.End.Column; i++)
                            width += worksheet.Column(i).Width;
            
                        break;
                    }
            }
            else //No merges - just get dimensions:
            {
                width = worksheet.Column(cell.Start.Column).Width;
                height = worksheet.Row(cell.Start.Row).Height;
            }
            
            //Convert point to pixels:
            top /= 0.75;
            left /= 0.1423;
            height /= 0.75;
            width /= 0.1423;
            return new Rectangle((int)left, (int)top, (int)width, (int)height);
        }
            
        bool Intersect(ExcelRange range, ExcelRangeBase cell)
        {
            foreach (ExcelRangeBase item in range)
                if (item.Address == cell.Address)
                    return true;
    
            return false;
        }
