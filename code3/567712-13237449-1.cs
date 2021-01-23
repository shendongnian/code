    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine(ConvertUnicodeEscapes("aa/u00C4bb/u00C4cc/u00C4dd/u00C4ee")); //  prints aaÄbbÄccÄddÄee
            }
            
            private static Regex r = new Regex("/u([0-9A-F]{4})");
            private static string ConvertUnicodeEscapes(string input)
            {
                return r.Replace(input, m => {
                    int code = int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                    return char.ConvertFromUtf32(code).ToString();                    
                } );
            }       
            
        }
    }
