    /// <summary>
    /// Json "extractor" capable of extracting a value of a key using the object notation.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString fn_GetKeyValue(SqlString json, SqlString key)
    {
        var jsonString = json.ToString();
        // Return if N/A
        if (string.IsNullOrEmpty(jsonString) || !JsonHelper.IsJson(jsonString))
        {
            return json;
        }
        var keyString = key.ToString();
        var jsonDictionary = JsonHelper.DeserializeJson(jsonString);
        var lastNode = string.Empty;
        foreach (var node in keyString.Split('.'))
        {
            if (!jsonDictionary.ContainsKey(node)) continue;
            var childDictionary = jsonDictionary[node] as Dictionary<string, object>;
            if (childDictionary != null)
            {
                jsonDictionary = childDictionary;
            }
            lastNode = node;
        }
        if (!jsonDictionary.ContainsKey(lastNode))
        {
            return null;
        }
        var keyValueString = jsonDictionary[lastNode].ToString();
        return keyValueString == "null" ? null : new SqlString(keyValueString);
    }
