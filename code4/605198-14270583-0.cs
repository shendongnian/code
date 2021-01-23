    static void Foo(string s)
    {
        try
        {
            s = "OK";
        }
        catch { }
    }
    static void Main(string[] args)
    {
        string temp = "??";
        Foo(temp);
        Console.WriteLine(temp); //prints ??
        Console.ReadLine();
    }
