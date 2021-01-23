    using System;
    using System.Collections.Generic;
     
    public class Test
    {
        public static void Main()
        {
            string string1 = "quick brown fox jumps over the lazy dog";
            foreach (var strSection in string1.SplitInto(8))
                Console.WriteLine("'{0}'", strSection);
        }
    }
    public static class MyExtensions
    {
        public static IEnumerable<string> SplitInto(this string value, int size)
        {
            for (int i = 0; i < value.Length; i += size)
            {
                if (i + size <= value.Length)
                    yield return value.Substring(i, size);
                else
                    yield return value.Substring(i);
            }
        }
    }
