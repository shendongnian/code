    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(\p{L}+)_");
            var input = "library_log_12312_12.log";
            var matches = regex.Matches(input);
            var match = matches[0];
            Console.WriteLine(match.Groups[0]); // library_
            Console.WriteLine(match.Groups[1]); // library
        }
    }
