    for (int i = 25; i <= lastRow; i += 4) // += means a + b
    {
        string cellName = "B" + i.ToString();
        string cellValue = ws.Range[cellName].Value;
        str.Add(cellValue);
    }
