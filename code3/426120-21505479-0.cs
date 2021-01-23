    cmd.Parameters.AddString("@MyParamName", myValue);
   
    public static class SQLExtension
    {
        public static void AddString(this SqlParameterCollection collection, string parameterName, string value)
        {
            collection.AddWithValue(parameterName, ((object)value) ?? DBNull.Value);
        }
    }
