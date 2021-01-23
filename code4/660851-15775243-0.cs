        public class People
        {
            [JsonProperty(PropertyName="people")]
            public IDictionary<string, Person> Persons { get; set; }
        }
        public class Person
        {
            [JsonProperty(PropertyName="name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
        }
