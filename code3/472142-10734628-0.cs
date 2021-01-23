    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
        public static void Main()
        {
            string search = @"The quick brown fox jumped over 4.55$, 5$, $45, $7.86";
            string regex = @"4.55\$, 5\$, \$45, \$7.86";
     
            Console.WriteLine("Searched and the result was... {0}!", Regex.IsMatch(search, regex));
        }
    }
