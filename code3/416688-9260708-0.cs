    private Func<string, string> _DoSomething;
    public ConfigureToLowerByExistingFunction()
    {
        _DoSomething = MyMakeItLowerImplementation;
    }
    public ConfigureToUpperByLambda()
    {
        _DoSomething = (input) => input.ToUpper();
    }
    public CallMe()
    {
        ConfigureToLowerByExistingFunction();
        //ConfigureToUpperByLambda();
        Console.WriteLine(_DoSomething("JuSt A StRiNG"));
    }
    private string MyMakeItLowerImplementation(string mystring)
    {
        return mystring.ToLower();
    }
