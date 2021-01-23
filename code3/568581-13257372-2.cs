    [Test()]
    public void GetAllSettingsTest()
    {
        //Arrange
        BsonDocument doc01 = new BsonDocument();
        BsonDocument doc02 = new BsonDocument();
        var mongoDatabase = new Mock<IMongoDBRepository>();
        var collection = new Mock<MongoCollection<BsonDocument>>();
        mongoDatabase.Setup(f => f.GetCollection(MongoCollection.Settings)).Returns(collection.Object);
        collection.Object.Insert(doc01);
        collection.Object.Insert(doc02);
       //rest of test
    }
