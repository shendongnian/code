    public class CustomerJson
    {
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
    public class Customer
    {
        [JsonProperty("first_name")]
        public string Firstname { get; set; }
        [JsonProperty("last_name")]
        public string Lastname { get; set; }
        ...
    }
