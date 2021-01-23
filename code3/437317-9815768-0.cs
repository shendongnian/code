    void SomeMethodA(string someString, Action<ResultsArgs<string>> operationCompleted)
    {
        MyContext.MethodA(someString, c =>
            {
                NewMethod(c, operationCompleted);
            }, null);
    }
    void SomeMethodA(string someString, Action<ResultsArgs<string>> operationCompleted)
    {
        MyContext.MethodB(c =>
            {
                NewMethod(c, operationCompleted);
            }, null);
    }
