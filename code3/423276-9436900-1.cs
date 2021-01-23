    public static class DataReaderExtensions 
    {
        public static T Read<T>(this SqlDataReader reader, string column, T defaultValue = default(T))
        {
            var value = reader[column];
            return (T)((DBNull.Value.Equals(value))
                       ? defaultValue
                       : Convert.ChangeType(value, typeof(T)));
        }
    }
