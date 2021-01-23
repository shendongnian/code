    foreach(Excel.Range curCol in inputRange.Columns)
    {
        if (curCol.Value2 != null) 
        {
           //As far as each column only has one row, each column can be associated with a cell
            string curVal = curCol.Value2.ToString();
        }
    }
