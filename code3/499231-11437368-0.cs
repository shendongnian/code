        using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "6A7FEBFCCC51268FBFF";
                for (int i = 0; i <= text.Length;i++ )
                    Console.WriteLine(hyphenate(text.Substring(0, i))); 
            } 
        
            static string hyphenate(string s)
            {
                var re = new Regex(@"(\w{4}\B)");
                return re.Replace (s, "$1-");
            }
            static string dehyphenate (string s)
            {
                return s.Replace("-", "");
            }
        } 
    }
