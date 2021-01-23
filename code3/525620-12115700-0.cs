    using System;
    using System.Text.RegularExpressions;
    namespace ExampleApp
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // This is your input string.
                string test = "Hello this is a 'test' a cool test!";
                // This is your RegEx pattern.
                string pattern = "(?<=').*?(?=')";
                // Get regex match object. You can also experiment with RegEx options.
                Match match = Regex.Match(test, pattern);
                // Print match value to console.
                Console.WriteLine(match.Value);
            }
        }
    }
