    for (var i = 0; i < dt.Rows.Count; i++)
    {
        var row = dt.Rows[i];
        for (var j = 0; j < dt.Columns.Count; j++)
        {
            var col = dt.Columns[j];
            Response.Write(row[col].ToString());
        }
    }
