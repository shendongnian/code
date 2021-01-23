    using System;    
        namespace temp
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string valu = "12345";
                    // **usage**
                    Console.WriteLine(valu.ToInt32());
                    Console.ReadLine();
                }
            }
            public static class MyExtentions
            {
                public static int ToInt32(this string s)
                {
                    if (s.Length > 1)
                        return Convert.ToInt32(s);
                    else
                    {
                        return 0;
                    }
                }
            }
        }
