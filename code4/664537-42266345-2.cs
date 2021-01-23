    public class Person
    {
        [JsonConverter(typeof(ConfigConverter<ILocation, Location>))]
        public ILocation Location { get;set; }
    }
