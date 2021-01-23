    var objectToSerialize = new List<IFoo>();
    // TODO: Add objects to list
    var jsonString = JsonConvert.SerializeObject(objectToSerialize,
           new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
    var deserializedObject = JsonConvert.DeserializeObject<List<IFoo>>(jsonString, 
           new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
