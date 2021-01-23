    public class JSQueryDocument : QueryDocument
    {
        public JSQueryDocument(string query) : base(MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(query))
        {
            // Probably better to do this as a method rather than constructor as it
            // could be hard to debug queries that are not formatted correctly
        }
    }
    /// ...
    var result = collection.Find(new JSQueryDocument("{ SendId: 4, 'Events.Code' : { $all : [2], $nin : [3] } }"));
