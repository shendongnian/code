    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Class1 obj = new Class1();
            obj.Dispose();
        }
        Console.ReadKey();
    }
