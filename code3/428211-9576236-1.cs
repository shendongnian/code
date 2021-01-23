    using (var streamReader = new StreamReader(stream, encoding))
    {
        Type modelType = null;
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            jsonTextReader.CloseInput = false;
            JToken token = JObject.Load(jsonTextReader);
            string type = (string)token.SelectToken("type");
            modelType = Type.GetType("Project." + type + ", Project");
        }
        
        streamReader.BaseStream.Position = 0;
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var obj = serializer.Deserialize(jsonTextReader, modelType);
        }
    }
