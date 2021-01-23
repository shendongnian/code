    [JsonObject(MemberSerialization.OptIn)]
    class Family
    {
        [JsonProperty(ItemConverterType = typeof(JsonRefedConverter))]
        public List<Person> persons;
    }
    [JsonObject(MemberSerialization.OptIn)]
    class Person : IJsonLinkable
    {
        [JsonProperty]
        public string name;
        [JsonProperty]
        public Pos pos;
        [JsonProperty, JsonConverter(typeof(JsonRefConverter))]
        public Person mate;
        [JsonProperty(ItemConverterType = typeof(JsonRefConverter))]
        public List<Person> children;
        string IJsonLinkable.Id { get { return name; } }
    }
    [JsonObject(MemberSerialization.OptIn)]
    class Pos
    {
        [JsonProperty]
        public int x;
        [JsonProperty]
        public int y;
    }
