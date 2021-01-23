    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                char[] input = CreateInput();
                DateTime start = DateTime.Now;
                for (int i = 1; i < 100; i++)
                {
                    StringCutter(new String(input));
                }
                Console.WriteLine((DateTime.Now - start).ToString());
                Console.ReadKey();
            }
            private static char[] CreateInput()
            {
                const int len = 10000;
                char[] ret = new char[len];
                for (int i = 0; i < len; i++)
                {
                    ret[i] = Convert.ToChar(i % 256);
                }
                return ret;
            }
            private static String StringCutter(String str)
            {
                List<char> exclusion = new List<char> { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
                StringBuilder result = new StringBuilder(str);
                for (int i = 0; i < result.Length; i++)
                {
                    if (!(exclusion.Contains(result[i])))
                    {
                        result.Remove(i, 1);
                        i--;
                    }
                }
                return result.ToString();
            }
        }
    }
