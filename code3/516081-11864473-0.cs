    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<char> exclusion = new List<char> { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
                String str = Console.ReadLine();
                StringBuilder result = new StringBuilder(str.Length);
                foreach (char c in str)
                {
                    if (!(exclusion.Contains(c)))
                    {
                        result.Append(c);
                    }
                }
                Console.WriteLine(result.ToString());
                Console.ReadKey();
            }
        }
    }
