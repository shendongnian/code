    public static DateTime? SafeGetDateTime(this OracleDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? null 
                                         : (DateTime?) reader.GetDateTime(colIndex);
    }
