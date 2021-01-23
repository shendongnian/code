    public static class Extensions
    {
        public static string TryGetValue(this IDictionary<string,string> dict, string key)
        {
            string value = null;
            if(dict.ContainsKey(key) && !string.IsNullOrWhiteSpace(dict[key]))
            {
                value = dict[key];
            }
            else
            {
                Logger.Write("Invalid argument : " + key);
            }
            return value;
        }
    
    }
