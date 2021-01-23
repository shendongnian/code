    static class SqlReaderExtension
    {
        public static async Task<T> ReadAsync<T>(this SqlDataReader reader, string fieldName)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentException("Value cannot be null or empty.", nameof(fieldName));
    
            int idx = reader.GetOrdinal(fieldName);
            return await reader.GetFieldValueAsync<T>(idx);
        }
    }
