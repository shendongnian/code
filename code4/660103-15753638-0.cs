    public class MyRootDTO
    {
      public Dictionary<String, MyChildDTO> Devices { get; set; }
    }
    public class MyChildDTO
    {
      [JsonProperty("Name")]
      public String Name { get; set; }
      [JsonProperty("Type")]
      public String Type { get; set; }
    }
    public class MyRoot
    {
      [JsonProperty("InsertMiracleCodeHere")]
      public String Key { get; set; }
      [JsonProperty("Name")]
      public String Name { get; set; }
      [JsonProperty("Type")]
      public String Type { get; set; }
    }
