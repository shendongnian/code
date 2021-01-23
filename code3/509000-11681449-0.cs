    public static JToken Rename(JToken json, Dictionary<string, string> map)
    {
        return Rename(json, name => map.ContainsKey(name) ? map[name] : name);
    }
    
    public static JToken Rename(JToken json, Func<string, string> map)
    {
        JProperty prop = json as JProperty;
        if (prop != null) 
        {
            return new JProperty(map(prop.Name), Rename(prop.Value, map));
        }
        
        JArray arr = json as JArray;
        if (arr != null)
        {
            var cont = arr.Select(el => Rename(el, map));
            return new JArray(cont);
        }
        
        JObject o = json as JObject;
        if (o != null)
        {
            var cont = o.Properties().Select(el => Rename(el, map));
            return new JObject(cont);
        }
        
        return json;
    }
