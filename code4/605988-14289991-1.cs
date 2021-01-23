    class Data{
      public string Name;
      public object Value;
    }
     Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Data>(yourjson.ToDictionary(x=>x.Name, y=>y.Value));
