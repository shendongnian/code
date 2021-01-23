    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var regex = new Regex("[<][^<]*[>]"); // or "[<]!--[^<]*--[>]"
                var input = "hello <!-- this is not meant to be here --> world, please help me";
                var output = regex.Replace(input, String.Empty); // hello  world, please help me
            }
        }
    }
