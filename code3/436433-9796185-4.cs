    public static GetDateTimeOrDefault(this IDataReader dr, string columnName, DateTime defaultValue)
    {
        int ordinal = dr.GetOrdinal(columnName);
        if (dr.IsDbNull(ordinal))
        {
            return defaultValue;
        }
        return dr.GetDateTime(ordinal);
    }
