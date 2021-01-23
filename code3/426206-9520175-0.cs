    using System.Xml;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    class Program {
        static void Main(string[] args) {
            string input = "124032";
            string[] invalid = { 
                "012345",
                "123456",
                // ...
                "000000",
                "111111",
                // ...
            };
            if (Regex.IsMatch(input, @"^\d{6}$") && !invalid.Contains(input)) {
                // ok
            }
        }
    }
