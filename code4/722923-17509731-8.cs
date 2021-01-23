    public class ApiRespose
    {
        public ApiRespose()
        {
            Notifications = new List<Notification>();
        }
        
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        [JsonProperty("notifications")]
        public List<Notification> Notifications { get; set; }
        [JsonProperty("response")]
        [JsonConverter(typeof(ResponseConverter))]
        public IResponse Response { get; set; }
    }
    
    public interface IResponse
    {
    }
    
    public class UserResponse : IResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        // Other properties
    }
    
    public class VenuesResponse : IResponse
    {
        public VenuesResponse()
        {
            Venues = new List<Venue>();
        }
        
        [JsonProperty("venues")]
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
        [JsonProperty("code")]
        public int Code { get; set; }
    }
    
    public class Notification
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("item")]
        public Item Item { get; set; }
    }
    
    public class Item
    {
        [JsonProperty("unreadcount")]
        public int UnreadCount { get; set; }
    }
