    public Foo GetFooByInfoName(string name)
    {
        Debug.Assert(name != null, "name is not an optional argument");
        var f = storedFoos.Values.Where(x => x.FooInfo.Name == name)
                                  .FirstOrDefault()//gets the first value or null
        return f;
    }
