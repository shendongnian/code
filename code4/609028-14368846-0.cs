    Excel.Range rng = ExWorksheet.UsedRange;
    int rowCount = rng.Rows.Count;
    int colCount = rng.Columns.Count;
    string[,] tsReqs = new string[rowCount, colCount];
    
    for (int i = 1; i <= rowCount; i++)
    {
        for (int j = 1; j <= colCount; j++)
        {
            string str = rng.Cells[i, j].Value2 as string;
            tsReqs[i - 1, j - 1] = str;
        }
    }
