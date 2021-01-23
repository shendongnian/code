    string json = @"{""identifier"": 232, ""type"": ""Feed2""}";
    var classa = JsonConvert.DeserializeObject<ClassA>(json);
.
    public interface InterfaceA
    {
        int Id { get; set; }
        FeedType Type { get; set; }
    }
    public class ClassA : InterfaceA
    {
        [JsonProperty("identifier")]
        public int Id{ get; set; }
        [JsonConverter(typeof(MyConverter))] //<--- !!!
        [JsonProperty("type")]
        public FeedType Type { get; set; }
    }
    [DataContract]
    public enum FeedType
    {
        [EnumMember(Value = "Feed1")]
        FeedA,
        [EnumMember(Value = "Feed2")]
        FeedB,
        [EnumMember(Value = "Feed3")]
        FeedC
    }
