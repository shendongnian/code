    private static Dictionary<string, CouchbaseClient> _clientDict = new Dictionary<string, CouchbaseClient>();
    
    public IStoreResult Set(string key, object value, string bucketName, string bucketPassword = "") 
    {
        if (! _clientDict.ContainsKey(bucketName))
        {
            _clientDict[bucketName] = new CouchbaseClient(bucketName); //assume this matches the config section name
        }
       
       return _clientDict[bucketName].ExecuteStore(StoreMode.Set, key, value);
    }
