    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            var input = "this=is+/* wrong!@# string^&*(";
            var output = Regex.Replace(input, "[^0-9A-Za-z]+", "-");
            Console.WriteLine(output);
        }                   
    }
