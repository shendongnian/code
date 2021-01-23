    class Program
    {
    static void Main()
    {
        for (int i = 0; i < 101; i++)
        {
            Console.WriteLine(TheMethod(i));
        }
    }
    static string TheMethod(int i)
    {
        string f = "Word1";
        string b = "Word2";
        if (i == 3) return f;
        if (i == 5) return b;
        if (0 == (i % 3)) return f;
        if (0 == i % 5) return b;
        return b;
    }
    }
