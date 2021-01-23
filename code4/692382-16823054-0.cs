    public class DocumentMetadata
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DownloadTime { get; set; }
    }
