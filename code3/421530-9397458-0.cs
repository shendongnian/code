    public class SafeDataReader : IDataReader, SqlDataReader
    {
        public IDataReader reader {get;set;}
        public int GetInt32(string aFieldName, int aDefault);
        public int? GetInt32Nullable(string aFieldName);
        .... 
    }
