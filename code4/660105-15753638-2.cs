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
      public String Key { get; set; }
      public String Name { get; set; }
      public String Type { get; set; }
    }
