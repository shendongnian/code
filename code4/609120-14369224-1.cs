    static T Deserialize<T>(string jsonText) where T : new()
    {
      var jsonBytes = Encoding.UTF8.GetBytes(jsonText);
      using (var stream = new MemoryStream(jsonBytes))
      {
        var serializer = new DataContractJsonSerializer(typeof(T));  
        var obj = serializer.ReadObject(stream) as T;
        return obj;
      }
    }
