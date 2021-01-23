    using System;
    using System.Globalization;
    class Program
    {
    static void Main()
    {
        int x = 4067;
        string s = x.ToString("x");
        Console.WriteLine(s);      // fe3
        s = String.Format("{0:x}", x);
        Console.WriteLine(s);      // fe3
        s = String.Format("{0:X}", x);
        Console.WriteLine(s);      // FE3
        s = String.Format("{0:x6}", x);
        Console.WriteLine(s);      // 000fe3
    }
    }
