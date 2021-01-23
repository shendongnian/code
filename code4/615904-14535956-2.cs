    public static void Main()
    {
        int value1 = GetD();   // <-- int
        List<string> result1 = Test("Value " + value1);
        // No problem, prints "Value 1", First() on List<string> works ok.
        Console.WriteLine(result1.First());
        dynamic value2 = GetD();   // <-- var
        dynamic result2 = Test("Value " + value2);
        // The below line gives RuntimeBinderException 
        // 'System.Collections.Generic.List<string>' does not contain a 
        // definition for 'First'
        Console.WriteLine(result2.First());
    }
result2 is a dynamic object, then extention method is not supported on it (used as extention method).
