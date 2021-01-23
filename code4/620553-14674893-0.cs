    var client = new MongoClient(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    var server = client.GetServer();
    
    DataLayer.Client = client;
    DataLayer.Server = server;
    
    var settings = new MongoDatabaseSettings(server, "default");			
    settings.WriteConcern = WriteConcern.Acknowledged;
    DataLayer.Database = DataLayer.GetDatabase(settings);
