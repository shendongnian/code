    string colSeperator = "\t";
    string rowSeperator = "\n";
    using (StreamWriter sw = File.CreateText(file))
    {
        for (int r = 0; r < originalDataTable.Rows.Count; r++)
        {
            for (int c = 0; c < originalDataTable.Columns.Count; c++)
            {
                sw.Write(originalDataTable.Rows[r][c])
                sw.Write(colSeperator);
            }
            sw.Write(rowSeperator);
        }
    }
