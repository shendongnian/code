    public T GenericMethod<T>(string key)
    {
        var ret = new object(); // Retrieve object from whatever...
        return (T) ret;
    }
    public void UsageExample()
    {
        int typedResult = GenericMethod<int>("myKey");
    }
