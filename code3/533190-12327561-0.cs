    private static Random s_rand = new Random();
    public static IEnumerable<int> Rand()
    {
        while (true)
            yield return s_rand.Next();
    }
    public static void Main()
    {
        var xs = Rand();
        var res = xs.Zip(xs, (l, r) => l == r).All(b => b);
        Console.WriteLine(res);
    }
