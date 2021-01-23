    public Object GetObject(string foo)
    {
        object pulledObject = null;
        someDict.TryGetValue(foo, out pulledObject);
        return pulledObject;
    }
