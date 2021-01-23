    Dictionary<KeyType, MyType> myDictionary = ...;
    Dictionary<KeyType, MyType>.TryGetResult result = myDictionary.TryGetValue(myKey);
    if (result.Succeeds)
    {
        MyType resultValue = result.Value;
    }
