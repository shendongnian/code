    void MethodThatDoesAllTheLogic(Action<string, string> addFunc)
    {
        // ...
        addFunc(key, value);
        // ...
    }
    public Dictionary<...> PopulateDictionary()
    {
        // ...
        MethodThatDoesAllTheLogic(result.Add);
    }
