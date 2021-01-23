    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        static void Main(string[] args)
        {
            string text = "ignored a      bc       d";
            Regex regex = new Regex(@"[a-z][\s]{4,}[a-z]");
            foreach (Match match in regex.Matches(text))
            {
                Console.WriteLine(match);
            }
        }
    }
