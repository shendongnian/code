    public class Report
    { 
         [BsonId, JsonIgnore]
         public ObjectId _id { get; set; }
 
         public string name { get; set; }
 
         [JsonIgnore]
         private BsonDocument layout { get; set; }
 
         [BsonIgnore]
         [JsonProperty(PropertyName = "layout")]
         public string layout2JSON
         { 
             get { return layout.ToJson(); }
         }
    }
