     JavaScriptSerializer serializer = new JavaScriptSerializer();
     
     // To serialize
     Dictionary<string, object> test = new Dictionary<string, object>(){ { "a", 1 } };
     string json = serializer.Serialize(test);
     // To deserialize (convert back to a .NET object)
     Dictionary<string, object> result = serializer.Deserialize<Dictionary<string, object>>(json);
