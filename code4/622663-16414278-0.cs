    MongoClient client = new MongoClient();
        MongoServer server = client.GetServer();
        MongoDatabase test = server.GetDatabase("test");
        MongoCredentials credentials = new MongoCredentials("username", "password");
        var databaseSettings = server.CreateDatabaseSettings("test");
        var database = server.GetDatabase(databaseSettings);
        BsonValue bv = test.Eval("GetSum",3,10 ); // return stored js function
