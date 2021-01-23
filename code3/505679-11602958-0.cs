    using System;
    using System.Text.RegularExpressions;
     
    class Program
    {
        static void Main()
        {
            string input = "...";
            Match match = Regex.Match(input, @"id&gt;([^,]*).*?name&gt;([^,]*)");
            if (match.Success)
            {
                Console.WriteLine(match.Groups[1].Value);
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
