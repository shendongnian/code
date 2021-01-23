        public Dictionary<string, object> Parse(string array)
        { 
            Dictionary<string, object> result = new Dictionary<string, object>();
            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(array);
            foreach (KeyValuePair<string, Newtonsoft.Json.Linq.JToken> kvp in obj)
            {
                if (kvp.Value.ToString().Contains('{'))
                {
                    result.Add(kvp.Key, Parse(kvp.Value.ToString().Replace("[", "").Replace("]", "")));
                }
                else
                {
                    result.Add(kvp.Key, kvp.Value.ToString());
                }
            }
            return result;
        } 
