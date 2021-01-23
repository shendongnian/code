    public KeyValuePair<Dictionary<int, int>, Dictionary<string, string>> GetDictionaries()
    {
        var dict1 = new Dictionary<int, int>();
        var dict2 = new Dictionary<string, string>();
        return new KeyValuePair<Dictionary<int, int>, Dictionary<string, string>>(dict1, dict2);
    }
    public void Method()
    {
        var result = GetDictionaries();
        var dict1 = result.Key;
        var dict2 = result.Value;
    }
