    private static void AddKeyValuePairs(
        NameValueCollection nvc,
        Dictionary<string, object> dict,
        string prefix = null)
    {
        foreach (var k in dict)
        {
            var key = prefix == null ? k.Key : prefix + "[" + k.Key + "]";
            if (k.Value != null)
                AddKeyValuePair(nvc, key, k.Value);
        }
    }
    private static void AddKeyValuePair(
        NameValueCollection nvc,
        string key,
        object value)
    {
        if (value is string || value.GetType().IsPrimitive)
        {
            nvc.Add(key, value.ToString());
        }
        else if (value is DateTime)
        {
            nvc.Add(key, ((DateTime)value).ToString("g"));
        }
        else
        {
            AddNonPrimitiveValue(nvc, key, value);
        }
    }
    private static void AddNonPrimitiveValue(
        NameValueCollection nvc,
        string key,
        object value)
    {
        var a = value as JArray;
        if (a != null)
        {
            for (int i = 0; i < a.Count; i++)
                AddKeyValuePair(nvc, key + "[" + i + "]", a[i]);
        }
        else
        {
            var v = value as JValue;
            if (v != null)
            {
                AddKeyValuePair(nvc, key, v.Value);
            }
            else
            {
                var j = value as JObject;
                if (j != null)
                    AddKeyValuePairs(nvc, j.ToObject<Dictionary<string, object>>(), key);
            }
        }
    }
