    private static object Deserialize(string json)
    {
        return ToObject(JToken.Parse(json));
    }
    private static object ToObject(JToken token)
    {
        if (token.Type == JTokenType.Object)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (JProperty prop in ((JObject)token).Properties())
            {
                dict.Add(prop.Name, ToObject(prop.Value));
            }
            return dict;
        }
        else if (token.Type == JTokenType.Array)
        {
            List<object> list = new List<object>();
            foreach (JToken value in token.Values())
            {
                list.Add(ToObject(value));
            }
            return list;
        }
        else
        {
            return ((JValue)token).Value;
        }
    }
