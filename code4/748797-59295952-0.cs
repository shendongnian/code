    public static T GetValue<T>(this DataRow row, string column)
    {
        if (!row.Table.Columns.Contains(column))
            return default(T);
		object value = row[ColumnName];
		if (value == DBNull.Value)
			return default(T);
		return (T)value;
    }
