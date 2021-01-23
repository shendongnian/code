    static void Main(string[] args)
    {
        Console.WriteLine("This text stays here");
        for (int a = 10; a >= 0; a--)
        {
            Console.Write("\rGenerating Preview in {0}", a);
            System.Threading.Thread.Sleep(1000);
        }
    }
