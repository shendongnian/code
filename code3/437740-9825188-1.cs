    foreach (DataRow row in dataSet11.DataTable1.Rows)
    {
        if (
            row.IsNull("ADDR3") // True if the value is null
            ||
            String.IsNullOrWhitespace(row["ADDR3"]) // True if the value is "", " ", etc.
           )
        {
            row["ADDR3"] = row["ADDR2"];
            row["ADDR2"] = " ";
        }
    }
