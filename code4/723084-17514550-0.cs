    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    
    class Program
    {
        private static Regex regex = new Regex(
            @"\[([0-9\-]{10}) ([0-9\.]+) (.+)\] (.+) (.+)", 
            RegexOptions.Compiled
        );
    
        public static void Main()
        {
            foreach (string line in File.ReadLines("log.txt"))
            {
                string[] parts = regex.Split(line);
                Console.WriteLine(
                    "date: {0}, ip: {1}, name: {2}, column 2: {3}, column 3: {4}", 
                    parts[1], 
                    parts[2], 
                    parts[3], 
                    parts[4], 
                    parts[5]
                );
            }
        }
    }
