    public static bool PropertyExists(dynamic obj, string name)
        {
            if (obj == null) return false;
            if (obj is ExpandoObject)
                return ((IDictionary<string, object>)obj).ContainsKey(name);
            if (obj is IDictionary<string, object> dict1)
                return dict1.ContainsKey(name);
            if (obj is IDictionary<string, JToken> dict2)
                return dict2.ContainsKey(name);
            return obj.GetType().GetProperty(name) != null;
        }
