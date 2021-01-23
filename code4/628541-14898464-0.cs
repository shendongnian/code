    internal static MongoDatabase DB(IMongoConfig config)
    {
        return MongoServer
               .Create(config.ConnectionString)    //This bit is getting the MongoServer
               .GetDatabase(config.DatabaseName);  //This bit gets the Database, which is returned
    }
