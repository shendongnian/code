    static void Test()
    {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            const string a = "-";
            const string b = "1";
            Console.WriteLine(String.Compare(a, b));                  // -1
            Console.WriteLine(String.Compare(a + "x", b + "x"));      // +1
    }
