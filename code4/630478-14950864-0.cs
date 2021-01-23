    public interface ICsvDataProvider
    {
        IEnumerable GetData(string filepath, Type recordType) 
        IEnumerable<TRecord> GetData<TRecord>(string filepath) 
            where TRecord : class;
    }
