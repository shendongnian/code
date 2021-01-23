    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Soundex
    {
        class Program
        {
            static char[] ignoreChars = new char[] { 'a', 'e', 'h', 'i', 'o', 'u', 'w', 'y' };
            static Dictionary<char, int> charVals = new Dictionary<char, int>()
            {
                {'b',1},
                {'f',1},
                {'p',1},
                {'v',1},
                {'c',2},
                {'g',2},
                {'j',2},
                {'k',2},
                {'q',2},
                {'s',2},
                {'x',2},
                {'z',2},
                {'d',3},
                {'t',3},
                {'l',4},
                {'m',5},
                {'n',5},
                {'r',6}
            };
    
            static void Main(string[] args)
            {
                Console.WriteLine(Soundex("txt"));
                Console.WriteLine(Soundex("text"));
                Console.WriteLine(Soundex("ext"));
                Console.WriteLine(Soundex("tit"));
                Console.WriteLine(Soundex("Cammmppppbbbeeelll"));
            }
    
            static string Soundex(string s)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(s.First());
                foreach (var c in s.Substring(1))
                {
                    if (ignoreChars.Contains(c)) { continue; }
    
                    // if the previous character yields the same integer then skip it
                    if ((int)char.GetNumericValue(sb[sb.Length - 1]) == charVals[c]) { continue; }
    
                    sb.Append(charVals[c]);
                }
                return string.Join("", sb.ToString().Take(4)).PadRight(4, '0');
            }
        }
    }
