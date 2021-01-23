    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace Testing
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(PatternFound("1 1 a"));
                Console.WriteLine(PatternFound("1     1    a"));
                Console.WriteLine(PatternFound("            1     1   a"));
    
            }
    
            static bool PatternFound(string str)
            {
                Regex regEx = new Regex("\\s");
                Match match = regEx.Match(str);
                return match.Success;
            }
        }
    }
