    public static T GetValue<T>(this OracleDataReader reader, string fieldName)
    {
        T result = default(T);
        int index = reader.GetOrdinal(fieldName);
        if (reader.IsDBNull(index))
        {
            return default(T);
        }
        if (typeof(T) == typeof(string))
        {
            result = (T)Convert.ChangeType(reader.GetString(index), typeof(T));
        }
        if (typeof(T) == typeof(int))
        {
            result = (T)Convert.ChangeType(reader.GetInt32(index), typeof(T));
        }
        if (typeof(T) == typeof(DateTime))
        {
            result = (T)Convert.ChangeType(reader.GetDateTime(index), typeof(T));
        }
        if (typeof(T) == typeof(byte[]))
        {
            OracleLob blob = reader.GetOracleLob(index);
            result = (T)Convert.ChangeType(blob.Value, typeof(T));
        }
        return result;
    }
