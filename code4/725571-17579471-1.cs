    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            string testString = "tHiSISaSTRINGwiThInconSISteNTcaPITaLIZATion";
            sw.Start();
            var re = new Regex("string", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
            for (int i = 0; i < 1000000; i++)
            {
                bool containsString = re.IsMatch(testString);
            }
            sw.Stop();
            Console.WriteLine("RX: " + sw.ElapsedMilliseconds);
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                bool containsStringRegEx = testString.ToUpper().Contains("STRING");
            }
            sw.Stop();
            Console.WriteLine("Contains: " + sw.ElapsedMilliseconds);
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                bool containsStringRegEx = testString.IndexOf("STRING", StringComparison.OrdinalIgnoreCase) >= 0 ;
            }
            sw.Stop();
            Console.WriteLine("IndexOf: " + sw.ElapsedMilliseconds);
        }
    }
