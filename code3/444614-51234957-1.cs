    public int CountNonDefaultProperties(object obj)
    {
        // Let JsonConvert do the work of stripping out default values
        var serialized = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore
        });
        // Recurse into the json structure, which is much simpler than C# Object structure
        var jObj = JObject.Parse(serialized);
        return CountJTokenProperties(jObj);
    }
