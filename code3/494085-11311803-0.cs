    enum myEnum { a, b, c }
    static void Main(string[] args)
    {
        var e = Enum.Parse(typeof(myEnum), "1");
        Console.WriteLine(e);
    }
