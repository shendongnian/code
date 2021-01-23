    public class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IResponse));
        }
        
        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                        object existingValue,
                                        JsonSerializer serializer)
        {
            // reader is forward only so we need to parse it
            var jObject = JObject.Load(reader);
            reader = jObject.CreateReader();
            
            if(jObject["user"] != null) // check if response is user
            {
                var user = serializer.Deserialize<UserResponse>(reader);
                return user;
            }
            
            if(jObject["venues"] != null) // check if response if venues
            {
                var venue = serializer.Deserialize<VenuesResponse>(reader);
                return venue;
            }
            
            throw new NotImplementedException("This reponse type is not implemented");
        }
        
        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            // Left as an exercise to the reader :)
            throw new NotImplementedException();
        }
    }
    
    public class ApiRespose
    {
        public ApiRespose()
        {
            Notifications = new List<Notification>();
        }
        
        public Meta Meta { get; set; }
        public List<Notification> Notifications { get; set; }
        [JsonConverter(typeof(ResponseConverter))]
        public IResponse Response { get; set; }
    }
    
    public interface IResponse
    {
    }
    
    public class UserResponse : IResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Other properties
    }
    
    public class VenuesResponse : IResponse
    {
        public VenuesResponse()
        {
            Venues = new List<Venue>();
        }
        
        public List<Venue> Venues { get; set; }
    }
    
    public class Venue
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        // Other Properties
    }
    
    public class Meta
    {
        public int Code { get; set; }
    }
    
    public class Notification
    {
        public string Type { get; set; }
        public Item Item { get; set; }
    }
    
    public class Item
    {
        public int UnreadCount { get; set; }
    }
