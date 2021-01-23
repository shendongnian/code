    using System;
    using System.Text.RegularExpressions;
     
    class P
    {
        static void Main()
        {
            Console.WriteLine(
                Regex.Match("//table[@data-account='test']//span[contains(.,'FB')]", "^([^]]+])").Groups[1].Value);
        }
    }
