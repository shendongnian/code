    foreach (DataRow row in table.Rows)
    {
        bool firstCol = true;
        foreach (DataColumn col in table.Columns)
        {
            if (!firstCol) sw.Write(", ");
            sw.Write(row[col].ToString());
            firstCol = false;
        }
        sw.WriteLine();
    }
