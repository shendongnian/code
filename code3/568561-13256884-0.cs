    public Object GetObject(string foo)
    {
        object pulledObject = null;
        if(someDict.ContainsKey(foo))
        {
            pulledObject = someDict[foo];
        }
        return pulledObject;
    }
