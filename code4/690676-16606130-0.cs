    enum Foo { A, B, C }
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i % ((int)Foo.C + 1));
        }
    }
