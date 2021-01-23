    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)   
    {
       foreach (var prop in objectType.GetProperties())
       {
          var type = prop.PropertyType;
          if (!type.IsClass)
              continue;
          var destination = Activator.CreateInstance(objectType);
          var result = reader.TokenType == JsonToken.StartArray 
                ? serializer.Deserialize(reader, objectType) 
                : new List<object> { serializer.Deserialize(reader, type) };
          return Mapper.Map(result, destination, result.GetType(), destination.GetType());
       }
   
          return null;
     }
