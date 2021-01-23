    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string letters = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ";
                Random random = new Random();
                string[] strings = Enumerable.Range(0, 5000).Select(i1 => string.Join("", Enumerable.Range(0,32000).Select(i2 => letters[random.Next(0, letters.Length - 1)]))).ToArray();
    
                Stopwatch stopwatchA = new Stopwatch();
                stopwatchA.Start();
    
                foreach (string s in strings)
                    Regex.Replace(s.ToUpper(), "[^0-9^A-F]", "");
    
                stopwatchA.Stop();
    
                Stopwatch stopwatchB = new Stopwatch();
                stopwatchB.Start();
    
                foreach (string s in strings)
                    Regex.Replace(s, "[^0-9^A-F^a-f]", "").ToUpper();
    
                stopwatchB.Stop();
    
                Debug.WriteLine("stopwatchA: {0}", stopwatchA.Elapsed);
                Debug.WriteLine("stopwatchB: {0}", stopwatchB.Elapsed);
            }
        }
    }
