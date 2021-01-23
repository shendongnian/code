    public class Person
    {
        public int Id { get; set; }
        
        [JsonProperty( NullValueHandling = NullValueHandling.Ignore )]
        public int? Reference { get; set; }
        public string Name { get; set; }
    }
