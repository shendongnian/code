    public void SomeMethod()
    {
        Func<List<object>, List<object>, Func<string, object>> test = (a, b) => 
        {
            a = b;
            return AnotherMethod;
        };
    }
    public object AnotherMethod(string value)
    {
        return (object)value;
    }
