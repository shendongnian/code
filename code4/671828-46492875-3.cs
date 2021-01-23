          public static TType JsonValue<TType>(this JObject obj, string key)
        {
            object result = null; //default to null if nothing is found
           
            foreach (var item in obj)
            {
                var token = item;
                if (token.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = token.Value.ToObject<TType>(); //return the value found
                    break; //if found break
                }
                if (!obj[token.Key].Children().Any())
                    continue;
                var jt = obj[token.Key].ToString();
                if (!jt.StartsWith("["))
                    result = JsonValue<TType>(JObject.Parse(jt), key);
             
                    obj[token.Key].Children().ToList().ForEach(x =>
                    {
                        //only the first match will be returned
                        result = JsonValue<TType>(JObject.Parse(x.ToString()), key);
                    });
                
                if (result != null)
                    break; //if found break
            }
            return (TType)result;
        }
