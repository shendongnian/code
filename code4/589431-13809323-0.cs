    public static void CallMethod(List<string> nameAndArguments)
    {
        var method = typeof(Program).GetMethod(nameAndArguments[0]);
        method.Invoke(null, nameAndArguments.Skip(1).ToArray()):
    }
