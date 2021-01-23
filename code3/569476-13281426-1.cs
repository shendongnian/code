    private static void SomeMethod() {
        string a = string.Empty;
        int b = 0;
        double c = 0;
        SetVariables(x => a = (string)x
                   , x => b = (int)x
                   , x => c = (double)x);
        Console.WriteLine("a: {0}\nb: {1}\nc: {2}", a, b, c);
    }
    public static void SetVariables(params Action<object>[] setters) {
        var tokens = new object[] { "Hello", 10, 14.235 };
        for (int i = 0; i < setters.Length; i++)
            setters[i](tokens[i]); // Assumed this is read and initialized properly
    }
