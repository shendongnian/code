    private Action<string, string> _DoSomething;
    public void ConfigureToSecondThanFirstByExistingFunction()
    {
        _DoSomething = MyMakeItLowerImplementation;
    }
    public void ConfigureToFirstThenSecondByLambda()
    {
        _DoSomething = (a, b) => Console.WriteLine(a + b);
    }
    public void CallMe()
    {
        ConfigureToSecondThanFirstByExistingFunction();
        //ConfigureToFirstThenSecondByLambda();
        _DoSomething("first", "second");
    }
    private void MyMakeItLowerImplementation(string a, string b)
    {
        Console.WriteLine(b + a);
    }
