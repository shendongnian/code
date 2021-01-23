    static void Main(string[] args)
    {
        Console.WriteLine(AddF("11"));
        Console.WriteLine(AddF("1T1"));
        Console.WriteLine(AddF("X"));
    }
    static string AddF(string s)
    {
        if (s.Length < 4)
            s = s.PadLeft(4, 'F');
        return s
    }
