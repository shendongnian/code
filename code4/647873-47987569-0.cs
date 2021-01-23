    using System;
    using System.Text.RegularExpressions;
    
    public class Example {
        public static void Main()
        {
            string pattern = @"(.*)\\(?<lcid>(?<locale>[a-z]{2})-?(?<region>[A-Z]{2})?)\\(.*)";
            string input = @"C:\MainFolder\Folder\en\translations.json C:\MainFolder\Folder\en-AU\translations.json";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        } 
    }
