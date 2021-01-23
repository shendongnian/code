    public void SomeMethod(Action<string> passedMethod)
    {
        passedMethod("some string");
    }
    public void Caller()
    {
        SomeMethod(x => Console.WriteLine(x));
    }
