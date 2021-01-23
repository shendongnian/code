        static async Task CreateIndex()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("HamsterSchool");
            var collection = database.GetCollection<Hamster>("Hamsters");
            var indexOptions = new CreateIndexOptions();
            var indexKeys = Builders<Hamster>.IndexKeys.Ascending(hamster => hamster.Name);
            var indexModel = new CreateIndexModel<Hamster>(indexKeys, indexOptions);
            await collection.Indexes.CreateOneAsync(indexModel);
        }
