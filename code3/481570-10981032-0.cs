    [JsonObject(MemberSerialization.OptIn)]
    public class MyClass
    {
        [JsonProperty(PropertyName = "creation_date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }
    }
