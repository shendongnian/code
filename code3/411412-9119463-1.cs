    using System;
    using System.Text.RegularExpressions;
    
    namespace Regex01
    {
        class Program
        {
            static string StripComments(string code)
            {
                var re = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
                return Regex.Replace(code, re, "$1");
            }
    
            static void Main(string[] args)
            {
                var input = "hello /* world */ oh \" '\\\" // ha/*i*/\" and // bai";
                Console.WriteLine(input);
    
                var noComments = StripComments(input);
                Console.WriteLine(noComments);
            }
        }
    }
