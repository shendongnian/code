    class Example
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] 
        public ObjectId ID { get; set; }
        public string EmailAddress { get; set; }
    }
    // Elsewhere in Code - nb you need to use the GetCollection<T> method so 
    // that your result gets serialized
    var result = database.GetCollection<Example>("users").FindAll().ToArray();
    var json = result.ToJson();
