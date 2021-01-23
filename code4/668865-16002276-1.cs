    [EdmFunction("MyNamespace", "fnTest")]
    public static int fnTest(int f1, int f2, int param3, int param4)
    {
        throw new NotSupportedException("Direct calls are not supported.");
    }
    
