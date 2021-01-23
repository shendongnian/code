    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            IDictionary<string, string> dictionary = 
                new Dictionary<string, string> {{ "a", "b" }};
            dictionary.Keys.Clear();
            Console.WriteLine(dictionary.Count);
        }
    }
