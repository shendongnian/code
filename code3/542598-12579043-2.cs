    public void SomeUtility(IConverter converter)
    {
        var myType = converter.Convert<MyType>("foo");
    }
    interface IConverter
    {
       T Convert<T>(object obj);
    }
