    public class Report
    {
        [BsonId, JsonIgnore]
        public ObjectId _id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public BsonDocument layout { get; set; }
        [BsonIgnore, JsonProperty(PropertyName = "layout")]
        [JsonConverter(typeof(CustomConverter))]
        public string layout2Json
        {
            get { return layout.ToJson(); }
        }
    }
