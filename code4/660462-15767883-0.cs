    IEnumerable<object> GetColumnValues(DataTable dt, int columnIndex)
    {
        if (dt.Columns.Count < columnIndex + 1)
            yield break;
        foreach (DataRow row in dt.Rows)
        {
            if (row[columnIndex] != DBNull.Value)
                yield return row[columnIndex];
        }
    }
