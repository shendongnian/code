        public static TType JsonValue<TType>(this JObject obj, string key)
        {
            object value = null; //default to null if nothing is found
            foreach (var item in obj)
            {
                if (item.Key.Equals(key,StringComparison.InvariantCultureIgnoreCase))
                return item.Value.ToObject<TType>(); //return the value found
              
                if (obj[item.Key].Children().Any())
                {
                    var jt = obj[item.Key].ToString();
                    if (!jt.StartsWith("["))
                       return JsonValue<TType>(JObject.Parse(jt), key);
                    //else
                    obj[item.Key].Children().ToList().ForEach(x =>
                    {
                        //only the last leaf will be returned
                       value = JsonValue<TType>(JObject.Parse(x.ToString()), key);
                    });
                }
            }
           return (TType)value;
        }
