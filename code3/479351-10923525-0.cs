    public static string GetJson(string json, string name)
    {
        JObject obj = JObject.Parse(json);
        JToken lastValue = obj.PropertyValues().Last();
        return lastValue[name].Value<string>();
    }
