    string colSeperator = "\t";
    string rowSeperator = "\n";
    using (StreamWriter sw = File.CreateText(file))
    {
        foreach (DataRow row in originalDataTable.Rows)
        {
            foreach (object value in row.ItemArray))
            {
                sw.Write(value)
                sw.Write(colSeperator);
            }
            sw.Write(rowSeperator);
        }
    }
