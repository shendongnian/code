    Type modelType = null;
    using (var streamReader = new StreamReader(stream, Encoding))
    using (var jsonTextReader = new JsonTextReader(streamReader))
    {
        JToken token = JObject.Load(jsonTextReader);
        var type = (string)token.SelectToken("type");
        modelType = Type.GetType("Project." + type + ", Project");
    }
    using (var streamReader = new StreamReader(stream, Encoding))
    using (var jsonTextReader = new JsonTextReader(streamReader))
    {
        var obj = serializer.Deserialize(jsonTextReader, modelType);
    }
