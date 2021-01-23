    using System;
    using System.Linq;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                string[] data = Enumerable.Range(10000, 100).Select(i => i.ToString()).ToArray();
                Parallel.ForEach(data, (item, state, index) => data[index] = Reverse(item));
                foreach (var s in data)
                    Console.WriteLine(s);
            }
            public static string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
    }
