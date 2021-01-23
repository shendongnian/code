    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {    
        public static void Main()
        {
            Regex regex = new Regex("\"\\p{Lu}+\"");
            string text = "oqr\"awr\"q q\"ASRQ\" asd \"qIKQWIR\"";
            
            Match match = regex.Match(text);
            Console.WriteLine(match.Success); // True
            Console.WriteLine(match.Value);   // "ASRQ"
        }    
    }
