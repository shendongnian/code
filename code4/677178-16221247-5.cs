    class P
    {
        static void M()
        {
            int x = 1;
            Func<int, int> f = y => x + y;
            x = 2;
            N(f);
        }
        static void N(Func<int, int> g)
        {
            int x = 3;
            Console.WriteLine(g(100));
        }
    }
