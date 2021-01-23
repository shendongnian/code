    public static class DataReaderExtensions {
        public static T Read<T>(this DataReader reader, string column, T defaultValue = default(T)) {
            var value = reader[column];
            return (DbNull.Equals(value)) 
                ? defaultValue
                : Convert.ChangeType (value, typeof(T));
        }
    }
