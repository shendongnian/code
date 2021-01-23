    static void Main()
    {
        await Task.WhenAll(YourFunction(), YourFunction(), YourFunction());
    }
    public async Task<string> YourFunction()
    {
        return new MyClass(GetValueFromDB()).GetData();
    }
