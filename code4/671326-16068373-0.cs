    string colSeperator = "\t";
    string rowSeperator = "\n";
    using (StreamWriter sw = File.CreateText(file))
    {
        for (int r = 0; r < originalDataTable.Rows.Count; r++)
        {
            for (int c = 0; c < originalDataTable.Columns.Count; c++)
            {
                var rowValueAtColumn = originalDataTable.Rows[r][c].ToString();
    
                var valueToWrite = string.Format(@"{0}{1}", rowValueAtColumn, colSeperator);
    
                sw.Write(valueToWrite);
            }
            sw.Write(rowSeperator);
        }
    }
