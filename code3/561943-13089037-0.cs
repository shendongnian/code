    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex("([^X]*)X");
            string input = "9234567X123456-789";
            Match match = regex.Match(input);
            // TODO: Check for success
            Console.WriteLine(match.Groups[1]); // 9234567
        }
    }
