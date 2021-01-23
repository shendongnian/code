    public Dictionary<string, object> JsonToDictionary(dynamic request)
    {
    JObject x = JObject.FromObject(request);
    Dictionary<string, object> result = new Dictionary<string, object>();
    
    foreach (JProperty prop in (JContainer)x)
        { 
           result.Add(prop.Name, prop.Value);
        }
    return result;
    }
