    static void Print1(string[] toPrint)
    {
        foreach(string s in toPrint)
        {
            Console.Write(s);
        }
    }
    static void Print2(string[] toPrint)
    {
        toPrint.ToList().ForEach(Console.Write);
    }
    static void Print3(string[] toPrint)
    {
        Console.WriteLine(string.Join("", toPrint));
    }
    static void Print4(string[] toPrint)
    {
        Array.ForEach(toPrint, Console.Write);
    }
