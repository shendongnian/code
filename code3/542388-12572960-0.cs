    using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var text = "[!product:123456:Click Me!]";
                var regex = new Regex("\\[!(.*):(.*):(.*)!\\]", RegexOptions.IgnoreCase);
    
                var result = regex.Replace(text, "<a href='http://www.mywebsite.com/$1/$2'> $3 </a>");
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }
