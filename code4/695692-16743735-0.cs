    private static string GetUrlParameters(string json)
    {
        JsonTextReader reader = new JsonTextReader(new StringReader(json));
        string path = null;
        List<string> list = new List<string>();
        while (reader.Read())
        {
            JsonToken tokenType = reader.TokenType;
            switch (tokenType)
            {
                case JsonToken.PropertyName:
                    path = reader.Path;
                    break;
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                    string item = string.Format("{0}={1}", path, reader.Value);
                    list.Add(item);
                    break;
            }
        }
        return string.Join("&", list);
    }
