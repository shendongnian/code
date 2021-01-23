    static int? x;
    static int? y;
    static void Main(string[] args)
    {
        x = 5;
        if (testx() & testy())
        {
            Console.WriteLine("test");
        }
    }
    static Boolean testx()
    {
        return x == 3;
    }
    static Boolean testy()
    {
        return y == 10;
    }
