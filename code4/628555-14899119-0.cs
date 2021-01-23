    public class User
        {        
            [JsonProperty("@First")]
            public string First{ get; set; }
            [JsonProperty("@Second")]
            public string Second{ get; set; }
    
            [JsonProperty("#text")]
            public string InnerValue { get; set; }
        }
 
