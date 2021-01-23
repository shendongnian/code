    public static class SqlDataReaderExtensions
    {
        public static string GetString(this SqlDataReader reader, string colName, string defIfNull)
        {
           int ordinalPos = reader.GetOrdinal(colName);
           return (!reader.IsDBNull(ordinalPos) ? defIfNull : reader.GetString(ordinalPos));
        }
    }
