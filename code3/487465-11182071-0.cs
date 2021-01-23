    public Dictionary<string, Dictionary<string, object>> DatatableToDictionary(DataTable dt, string id)
    {
        var cols = dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != id);
        return dt.Rows.Cast<DataRow>()
                 .ToDictionary(r => r[id].ToString(), 
                               r => cols.ToDictionary(c => c.ColumnName, c => r[c.ColumnName]));
    }
