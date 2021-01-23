    using System;
    
    namespace temp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string valu = "";
                Console.WriteLine(valu.ToInt32());
                Console.ReadLine();
            }
        }
        public static class MyExtentions
        {
            public static int ToInt32(this string s)
            {
                int x;
                if (s != null)
                {
                    if (s.Length > 1)
                        x = Convert.ToInt32(s);
                    else
                        x = 0;
                }
                else
                {
                   x= 0;
                }
                return x;
            }
        }
    }
