    public void Method_2(params object[] values)
    {
        var argNo = 0;
        var dictionary = values.ToDictionary(x => "Arg" + ++argNo);
    }
    public void Method_1(string arg1, string arg2)
    {
        // ...
        Method_2(arg1, arg2);
    }
