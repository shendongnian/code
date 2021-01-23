    Excel.Range Unionize(Excel.Range src)
    {
        Excel.Range unionizedRange;
    
        foreach (Excel.Range cell in src)
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
