    using System;
    using System.Text.RegularExpressions;
    namespace DemoRegExForStackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                var regex = new Regex(@"(?<col>([A-Z]|[a-z])+)(?<row>(\d)+)");
                var input = @"AB12";
                var match = regex.Match(input);
                if( match != null )
                {
                    var col = match.Groups["col"];
                    var row = match.Groups["row"];
                    Console.WriteLine("Input is: {0}", input);
                    Console.WriteLine("Column is {0}", col.Value);
                    Console.WriteLine("Row is {0}", row.Value);
                 }
                 else
                 {
                     throw new ArgumentException("Invalid input");
                 }
            }
        }
    }
