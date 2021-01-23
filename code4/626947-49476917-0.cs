    Task<bool> Update(string Id, T item)
    {
        var serializerSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                };
    	var bson = new BsonDocument() { { "$set", BsonDocument.Parse(JsonConvert.SerializeObject(item, serializerSettings)) } };
    	await database.GetCollection<T>(collectionName).UpdateOneAsync(Builders<T>.Filter.Eq("Id", Id), bson);
    }
