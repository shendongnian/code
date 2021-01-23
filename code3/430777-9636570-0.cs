    private static void Main(string[] args)
    {
        MyDelegate myDelegate1 = delegate {
            Console.WriteLine("Test 1");
        };
        MyDelegate myDelegate2 = delegate {
            Console.WriteLine("Test 2");
        };
        myDelegate1();
        myDelegate2();
        Console.ReadKey();
    }
