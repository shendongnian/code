    public static class DataReaderExtensions
    {
        public static long? GetNullableInt64(this IDataReader reader, int index)
        {
            if (reader.IsDBNull(index))
                return null;
    
            return reader.GetInt64(index);
        }
    }
