    static void Main(string[] args)
    {
        int j = 0;
        Func<int> f = () =>
        {
            int k = j;
            for (int i = 0; i < 3; i++)
            {
                k += i;
            }
            return k;
        };
        int myStr = f();
        Console.WriteLine(myStr);
        Console.WriteLine(j);
        Console.Read();
    }
