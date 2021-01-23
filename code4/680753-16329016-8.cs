    static void Main(string[] args)
    {
        var s = new MYSTRUCT();
        Console.WriteLine(MyProc(ref s)); // you must use "ref" when passing an argument
        Console.WriteLine(s.field2);
        Console.ReadKey();
    }
