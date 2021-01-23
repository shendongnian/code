    using System;
    using System.Linq;
    
    public static class StringExtensions
    {
        public static int NthLastIndexOf(this string value, char c, int n = 1)
        {
            var index = 1;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (value[i] == c)
                {
                    if (index == n)
                    {
                        return i;
                    }
                    index++;
                }
            }
            return -1;
        }
    }
    
    class Program
    {
        public static string GetEndOfPath(string path)
        {
            var idx = path.NthLastIndexOf('/', 2);
            if (idx == -1)
            {
                throw new ArgumentException("path does not contain two separators.");
            }
    
            return path.Substring(idx + 1);
        }
    
        static void Main()
        {
            var result = GetEndOfPath("http://users/test/test/program/test/test.avi");
            Console.WriteLine(result);
        }
    }
