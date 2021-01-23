    using System;
    using System.Globalization;
    
    class Program
    {
        static void Main()
        {
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            var options = CompareOptions.IgnoreCase | 
                CompareOptions.IgnoreSymbols |
                CompareOptions.IgnoreNonSpace;
            
            var haystack = "bla Lé OnAr d/o bla";
            var needle = "leonardo";
            
            var index = compareInfo.IndexOf(haystack, needle, options);
            Console.WriteLine(index); // 4
        }
    }
