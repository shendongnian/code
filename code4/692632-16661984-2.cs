    public class tweet
    {
        public string max_id_str { get; set; }
        [JsonProperty("results")]
        [JsonConverter(typeof(TextPropertyResultExtractorConverter))]
        public string text { get; set; }
        public string results_per_page{ get; set; }
        public string since_id { get; set; }
        public string since_id_str { get; set; }
    }
    
    public class TextPropertyResultExtractorConverter : JsonConverter
    {
        public override bool CanConvert(Type type)
        {
            throw new NotImplementedException();
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var results = (JArray)serializer.Deserialize(reader);
            var firstResult = results.First();
            return firstResult["text"].Value<string>();
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
