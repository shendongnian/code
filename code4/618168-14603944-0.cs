    private string PrivateMethod<T>(string value, Dictionary<string, object[]> parameters)
    {
        foreach (KeyValuePair<string, object[]> kvp in parameters)
        {
               T[] items = kvp.Value.Cast<T>().ToArray();
               [...]
        }
    
        [...]
    }
