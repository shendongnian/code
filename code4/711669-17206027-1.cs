    for (int i = 0; i < rowCount; i++)
    {
        List<string> row = new List<string>();
        for (int j = 0; j < colCount; j++)
        {
            string cellText="";
            int maxLoops = 10;
            int loop = 0;
            bool successfulRead = false;
            while (!successfulRead && loop < maxLoops)
            {
                Excel.Range cellVal = (Excel.Range)allCells.Cells[i + 1, j + 1]; //Excel ranges are 1 indexed not 0 indexed
                cellText = cellVal.Text.ToString();
                if (!Regex.IsMatch(cellText, @"#+"))
                {
                    successfulRead = true;
                }
                else
                {
                    cellVal.EntireColumn.ColumnWidth = Math.Min((double)cellVal.EntireColumn.ColumnWidth + 5, 255);
                }
                loop++;
            }
            if (cellText != "")
            {
                row.Add(cellText);
            }
    
        }
        if (row.Count > 0)
        {
            nonBlankValues.Add(row);
        }
    }
