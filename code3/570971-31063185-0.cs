    public class Something {
    
        [BsonId]
        public string Id { get; set; }
    
        public Something() {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    
    }
