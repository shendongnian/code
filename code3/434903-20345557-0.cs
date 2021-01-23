    public string myFunction(string name)
    {
        return "Hello " + name;
    }
    public string functionPointerExample(Func<string,string> myFunction)
    {
        myFunction("Theron");
    }
