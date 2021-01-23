    public static class JsonHelper
    {
        public static JToken ReadFrom(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
                return JToken.ReadFrom(jsonReader);
        }
    }
