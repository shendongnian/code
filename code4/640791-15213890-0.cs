    using System;
    using System.Diagnostics;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            string[] source = GenerateRandomStrings();
            string[] workingSpace = new string[source.Length];
            
            CopyAndSort(source, workingSpace);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                CopyAndSort(source, workingSpace);
            }
            sw.Stop();
            Console.WriteLine("Elapsed time: {0}ms", 
                              (long) sw.Elapsed.TotalMilliseconds);
        }
            
        static string[] GenerateRandomStrings()
        {
            Random rng = new Random();
            string[] ret = new string[10000];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = GenerateRandomString(rng);
            }
            return ret;
        }
        
        static string GenerateRandomString(Random rng)
        {
            char[] chars = new char[30];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char) rng.Next('A', 'z' + 1);
            }
            return new string(chars);
        }
        
        static void CopyAndSort(string[] original, string[] workingSpace)
        {
            Array.Copy(original, 0, workingSpace, 0, original.Length);
            Array.Sort(workingSpace);
            // Array.Sort(workingSpace, StringComparer.Ordinal);
        }
    }
