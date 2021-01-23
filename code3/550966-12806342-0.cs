    class MyValue
    {
      public string Key {get; set;}
      public string Value {get; set;}
    }
    JsonConvert.DeserializeObject<List<MyValue>>(text);
