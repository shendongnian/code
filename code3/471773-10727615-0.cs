    [Flags]
    public enum DoSomethingOptions
    {
        None = 0,
        UseClass1 = 1,
        UseClass2 = 2,
        UseClass3 = 4,
        etc..
    }
    DoSomething(Class1 class1, ..., DoSomethingOptions options = DoSomethingOptions.None) { ... }
