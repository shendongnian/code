    public class Attributes
    {
        [JsonProperty("name")]
        public String Name { get; set; }
        
        [JsonProperty("quantity")]
        public Int32 Quantity { get; set; }
    }
    public class MyObject
    {
        [JsonProperty("Attributes")]
        public Attributes Attributes { get; set; }
    }
    var myObj = JsonConvert.DeserializeObject<MyObject>(json);
