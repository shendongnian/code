    static void Main(string[] args)
    {
        string str = "hello";
        SomeFunction(ref str);
        Console.WriteLine(str); // outputs "world"
    }
    static void SomeFunction(ref string obj)
    {
        obj = "world";
    }
