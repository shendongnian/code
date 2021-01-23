    using System;
    public class Test
    {
        public static void Main()
        {
            String s = "\u0001 This is a test \u0001";
            s = s.Replace("\u0001","Yay!");
            Console.WriteLine(s);
        }
    }
