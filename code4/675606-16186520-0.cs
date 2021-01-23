    public class Customer
    {
        public string name { get; set; }
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public string idCol { get; set; }
    }
