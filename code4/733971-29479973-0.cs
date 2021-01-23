    static async Task CreateIndex()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("HamsterSchool");
        var collection = database.GetCollection<Hamster>("Hamsters");
        await collection.Indexes.CreateOneAsync(Builders<Hamster>.IndexKeys.Ascending(_ => _.Name));
    }
