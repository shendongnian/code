    static void Main(string[] args)
    {
        Logger.Invoke(new Action<int>(CountTo), 10);
        Console.WriteLine("5 * 2 = {0}", Logger.Invoke<int>(new Func<int, int>(TwiceAsBig), 5));
    }
    static void CountTo(int num)
    {
        for (int i = 1; i <= num; ++i)
            Console.WriteLine(i);
    }
    static int TwiceAsBig(int num)
    {
        return num * 2;
    }
