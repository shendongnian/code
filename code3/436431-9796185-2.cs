    public static GetDateTimeOrDefault(this MySqlDataReader dr, string columnName, DateTime defaultValue)
    {
        if (dr.IsDbNull(columnName))
        {
            return defaultValue;
        }
        return dr.GetDateTime(columnName);
    }
