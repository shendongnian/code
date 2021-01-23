    class Program
    {
    static void Main()
    {
        for (int i = 0; i < 101; i++)
        {
            Console.WriteLine(TheMethod(i).ToString());
        }
    }
    static string TheMethod(int i)
    {
        string f = "Word1";
        string b = "Word2";
        if (i == 3) return f;
        else if (i == 5) return b;
        else if (0 == (i % 3)) return f;
        else if (0 == i % 5) return b;
        else return b;
    }
    }
