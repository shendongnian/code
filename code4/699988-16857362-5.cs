    class Item {
      public Int32 id { get; set; }
  
      [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
      public String text { get; set; }
  
      [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
      public Item[] item { get; set; }
  
    }
