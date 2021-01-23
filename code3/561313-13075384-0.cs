    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            var lst1 = new List<int> { 1, 2, 3, 4 };
            var lst2 = new List<int> { 1, 2, 3, 4 };
            var lst3 = new List<int> { 2, 3, 4, 5 };
            
            Console.WriteLine(lst1.SequenceEqual(lst2)); // True
            Console.WriteLine(lst1.SequenceEqual(lst3)); // False
        }
    }
