    foreach (DataRow row in ds.Tables[0].Rows)
    {
        foreach (DataColumn c in ds.Tables[0].Columns)
        {
            if (row.IsNull(c))
            {
                try
                {
                    row[c] = string.Empty;
