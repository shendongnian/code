    public class Organisation
    {
        public Contacts contacts;
    }
    
    public class Address
    {
        public string id;
        public string street;
        public string city;
        public string type;
        public string zip;
        public string country;
    }
    
    public class Contacts
    {
        // Tell JSON.net to use the custom converter for this property.
        [JsonConverter(typeof(JsonToArrayConverter<Address>))]
        public Address[] address;
    }
