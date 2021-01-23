    public class abstract MongoEntityBase
    {
        public ObjectId Id {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Version { get; set; }
    }
