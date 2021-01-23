    public class HashTableDocument
    {
        public ObjectId Id { get; set; }
        [BsonExtraElements]
        public Dictionary<string, object> Values { get; set; }
    }
