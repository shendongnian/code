    public static object Column(this DataRow source, string columnName)
    {
        var c = source.Table.Columns[columnName];
        if (c != null)
        {
            return source.ItemArray[c.Ordinal];
        }
        throw new ObjectNotFoundException(string.Format("The column '{0}' was not found in this table", columnName));
    }
