    // Could be generic of course, but let's keep things simple...
    public bool ContainsKeyValue(Dictionary<string, int> dictionary,
                                 string expectedKey, int expectedValue)
    {
        int actualValue;
        if (!dictionary.TryGetValue(expectedKey, out actualValue))
        {
            return false;
        }
        return actualValue == expectedValue;
    }
