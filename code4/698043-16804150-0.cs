    // sample class with a property that could contain the sample string 
    // in your example, "This is a cool stock. $MSFT"
    public class Talk {
      public string Message { get; set; } 
    }
    
    var client = new MongoClient("mongodb://localhost");
    var server = client.GetServer();
    var database = server.GetDatabase("stocktalk");
    var collection = database.GetCollection<Talk>("talk");
    
    var query = Query<Talk>.EQ(m => m.Message, 
                               new BsonRegularExpression(@"\$MSFT"));
    // get all of the Talk objects that match
    var matches = collection.FindAs<Talk>(query);
