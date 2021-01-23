    public async Task<dynamic> GetAll(string collectionName)
    {
    	//var collection = db.GetCollection<BsonDocument>(collectionName);
    	//var result = await collection.Find(new BsonDocument()).ToListAsync();
    	var collection = db.GetCollection<dynamic>(collectionName);
    	return await collection.Find(new BsonDocument()).ToListAsync();
    }
