            var message = string.Empty;
            
            var serverSettings = new MongoServerSettings()
            {
                GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard,
                ReadEncoding = new UTF8Encoding(),
                ReadPreference = new ReadPreference(),
                WriteConcern = new WriteConcern(),
                WriteEncoding = new UTF8Encoding()
            };
            var server = new Mock<MongoServer>(serverSettings);
            server.Setup(s => s.Settings).Returns(serverSettings);
            server.Setup(s => s.IsDatabaseNameValid(It.IsAny<string>(), out message)).Returns(true);
            var databaseSettings = new MongoDatabaseSettings()
            {
                GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard,
                ReadEncoding = new UTF8Encoding(),
                ReadPreference = new ReadPreference(),
                WriteConcern = new WriteConcern(),
                WriteEncoding = new UTF8Encoding()
            };
            var database = new Mock<MongoDatabase>(server.Object, "test", databaseSettings);
            database.Setup(db => db.Settings).Returns(databaseSettings);
            database.Setup(db => db.IsCollectionNameValid(It.IsAny<string>(), out message)).Returns(true);
    
            var mockedCollection = collection.Object;
