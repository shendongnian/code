    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    
    class Test
    {
        public static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var lines = from line in File.ReadLines("input.txt")
                        let cpf = ParseCpf(line)
                        let xml = ParseXml(line)
                        from year in ParseYears(line)
                        select cpf + year + xml;
                        
            File.WriteAllLines("output.txt", lines);
            stopwatch.Stop();
            Console.WriteLine("Completed in {0}ms", stopwatch.ElapsedMilliseconds);
        }
        
        // Returns the CPF, in the form "CPF=xxxxxx;"
        static string ParseCpf(string line)
        {
            int start = line.IndexOf("CPF=");
            int end = line.IndexOf(";", start);
            // TODO: Validation
            return line.Substring(start, end + 1 - start);
        }
        
        // Returns a sequence of year values, in the form "YEAR=2010;"
        static IEnumerable<string> ParseYears(string line)
        {
            // First year.
            int start = line.IndexOf("YEARS=") + 6;
            int end = line.IndexOf(" ", start);
            // TODO: Validation
            string years = line.Substring(start, end - start);
            foreach (string year in years.Split(';'))
            {
                yield return "YEARS=" + year + ";";
            }
        }
        
        // Returns all the XML from the leading space onwards
        static string ParseXml(string line)
        {
            int start = line.IndexOf(" <?xml");
            // TODO: Validation
            return line.Substring(start);
        }
    }
