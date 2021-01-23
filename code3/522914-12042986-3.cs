    public class Person 
    {
        [JsonConverter(typeof(EscapeQuoteConverter))]
        public string Name { get; set; } 
    }
