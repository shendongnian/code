    private static void ExecuteBoolResult(Func<bool> method)
    {
        bool result = method();
        if (!result)
        {
            throw new InvalidOperationException("method did not return true");
        }
    }
    CheckBoolResult(() => AnotherFunction("with ", 3, " parameters"));
    CheckBoolResult(() => AnotherFunction(2, "parameters"));
