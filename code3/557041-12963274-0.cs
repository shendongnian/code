    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            ShowPairHash("a", "b");
            ShowPairHash("a", "c");
            ShowPairHash("Z", "0");
            ShowPairHash("Z", "1");
        }
        
        static void ShowPairHash(string x, string y)
        {
            var pair = new KeyValuePair<string, string>(x, y);
            Console.WriteLine(pair.GetHashCode());
        }
    }
