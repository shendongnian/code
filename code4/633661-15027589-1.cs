    public B (string objectName) : base (SomethingComplex(objectName))
    {
        //...
    }
    static MyObject SomethingComplex(string objectName)
    {
        // this can now be arbitrarily complex
        if(string.IsNullOrWhiteSpace(objectName))
            throw new ArgumentException("objectName")
        // etc
        return new MyObject(objectName);
    }
