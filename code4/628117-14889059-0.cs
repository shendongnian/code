    public static class JTokenExt
    {
        public static Dictionary<string, object> 
             Bagify(this JToken obj, string name = null)
        {
            name = name ?? "obj";
            if(obj is JObject)
            {
                var asBag =
                    from prop in (obj as JObject).Properties()
                    let propName = prop.Name
                    let propValue = prop.Value is JValue 
                        ? new Dictionary<string,object>()
                            {
                                {prop.Name, prop.Value}
                            } 
                        :  prop.Value.Bagify(prop.Name)
                    select new KeyValuePair<string, object>(propName, propValue);
                return asBag.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            if(obj is JArray)
            {
                var vals = (obj as JArray).Values();
                var alldicts = vals
                    .SelectMany(val => val.Bagify(name))
                    .Select(x => x.Value)
                    .ToArray();
                return new Dictionary<string,object>()
                { 
                    {name, (object)alldicts}
                };
            }
            if(obj is JValue)
            {
                return new Dictionary<string,object>()
                { 
                    {name, (obj as JValue)}
                };
            }
            return new Dictionary<string,object>()
            { 
                {name, null}
            };
        }
    }
