    [OperationContract]
    [AspNetCacheProfile("CacheFor60Seconds")]
    [WebGet]
    public List<string> GetAll()
    {
        return Names;
    }
