    using System;
    using System.Text.RegularExpressions;
    
    namespace PostCodeValidator
    {
        class Program
        {
            static void Main(string[] args)
            {
                var regex = new Regex(@"^[0234567]{1}\d{3}$");
                var input = String.Empty;
    
                while (input != "exit")
                {
                    input = Console.ReadLine();
                    Console.WriteLine(regex.IsMatch(input));
                }
            }
        }
    }
