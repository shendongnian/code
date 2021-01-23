    public static T ParseJSON<T>(string jsonString, Dictionary<string, string> mappingTable = null)
    {
        Dictionary<string, object> jsonDictionary = ParseJSON(jsonString);
        T castedObj = CastAs<T>(jsonDictionary, mappingTable);
        return castedObj;
    }
