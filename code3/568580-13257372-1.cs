    private IMongoDBRepository _mongoDBRepository; //this gets injected
    public List<BsonDocument> GetAllSettings()
    {
        var collection = _mongoDBRepository.GetCollection<BsonDocument>("Settings");
        var query = from e in collection.AsQueryable()
                    select e;
        var settings = query.ToList();
        return settings;
    }
