    private static int count = 0;
    public static IEnumerable<int> Regurgitate(IEnumerable<int> source)
    {
        count++;
        Console.WriteLine("Iterated sequence {0} times", count);
        foreach (int i in source)
            yield return i;
    }
    int[] Numbers = new int[5] { 5, 2, 3, 4, 5 };
    
    IEnumerable<int> sequence = Regurgitate(Numbers);
    
    var query = from a in sequence
                where a == sequence.Max(n => n)
                select a;
