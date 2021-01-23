    public static class DataReaderExtensions
    {
      public static DateTime? ReadNullableDateTime(this IDataReader reader, string column)
        {
            return reader.IsDBNull(column) ? (DateTime?)null : reader.GetDateTime(column);
        }
    }
