	static async Task CreateIndex(string connectionString)
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase("HamsterSchool");
		var collection = database.GetCollection<Hamster>("Hamsters");
		var indexOptions = new CreateIndexOptions();
		var indexKeys = Builders<Hamster>.IndexKeys.Ascending(hamster => hamster.Name);
		var indexModel = new CreateIndexModel<Hamster>(indexKeys, indexOptions);
		await collection.Indexes.CreateOneAsync(indexModel);
	}
