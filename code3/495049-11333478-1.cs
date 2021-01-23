    public static class DbDataReaderExt {
        public static T GetOrDefault<T>(this DbDataReader reader, int index, T default_value = default(T)) {
            if (reader.IsDBNull(index))
                return default_value;
            return (T)reader[index];
        }
    }
