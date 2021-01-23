    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            var input = "WhoAmI";
            var output = Regex.Replace(input, @"\p{Lu}", " $0").TrimStart();
            Console.WriteLine(output);
        }
    }
