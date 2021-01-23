    Excel.Range Unionize(Excel.Range src)
    {
        Excel.Range cell;
        Excel.Range unionizedRange;
    
        foreach (cell in src)
        {
            if (unionizedRange == null)
            {
                unionizedRange = cell;
            }
            Else
            {
                unionizedRange = Application.Union(unionizedRange, cell);
            }
        }
        return unionizedRange;
    }
