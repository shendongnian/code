    public static GetDateTimeOrDefault(this MySqlDataReader dr, string columnName, DateTime defaultValue)
    {
        int ordinal = dr.GetOrdinal(columnName);
        if (dr.IsDbNull(ordinal))
        {
            return defaultValue;
        }
        return dr.GetDateTime(ordinal);
    }
