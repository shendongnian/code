    /// <summary>
    /// Serializes object to JSON format
    /// </summary>
    /// <param name="input">Object</param>
    /// <returns>JSON string</returns>
    public static string SerializeObject(Object input, bool debug = true)
    {
        string json = JsonConvert.SerializeObject(input, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, MaxDepth = 2 });
        if (debug)
        {
            return "<pre>" + json + "</pre>"; // In order to preview in browser
        }
    
        return json;
    }
    
    /// <summary>
    /// Serializes Request.Form (NameValueCollection) to JSON format
    /// </summary>
    /// <param name="input">NameValueCollection</param>
    /// <returns>JSON string</returns>
    public static string SerializePostRequest(NameValueCollection post)
    {
        var dict = new Dictionary<string, string>();
        foreach (string key in post.Keys)
        {
            dict.Add(key, post[key]);
        }
    
        return SerializeObject(dict);
    }
