    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn col in dt.Columns)
        {
            Response.Write(row[col].ToString());
        }
    }
    // or
    foreach (var row in dt.Rows.Cast<DataRow>())
    {
        foreach (var col in dt.Columns.Cast<DataColumn>())
        {
            Response.Write(row[col].ToString());
        }
    }
