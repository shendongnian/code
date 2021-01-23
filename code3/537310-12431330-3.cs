        private static Regex RegexSearch = new Regex("Audi A4", RegexOptions.Compiled);
        static void Main(string[] args)
        {            
            // warm up the JIT compiler
            FoundWithRegexIsMatch();
            FoundWithStringContains();
            FoundWithStringIndexOf();
            // done warming up
            int iterations = 100;
            var sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                FoundWithRegexIsMatch();
            }
            sw.Stop();
            Console.WriteLine("Regex.IsMatch: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                FoundWithStringIndexOf();
            }
            sw.Stop();
            Console.WriteLine("String.IndexOf: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                FoundWithStringContains();
            }
            sw.Stop();
            Console.WriteLine("String.Contains: " + sw.ElapsedMilliseconds + " ms");
        }
        private static bool FoundWithStringContains()
        {
            return Resource2.csv.Contains("Audi A4");
        }
        private static bool FoundWithStringIndexOf()
        {
            return Resource2.csv.IndexOf("Audi A4") >= 0;
        }
        private static bool FoundWithRegexIsMatch()
        {
            return RegexSearch.IsMatch(Resource2.csv);
        }
