    using System;
    using System.Collections.Generic;
    class BasicIntSet
    {
        static void Main()
        {
            HashSet<int> intTest = new HashSet<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
            Console.WriteLine(intTest.Contains(4)); // True
            Console.WriteLine(intTest.Contains(11)); // False
            Console.WriteLine(intTest.IsSupersetOf(new[] { 4, 6, 7 })); // True
        }
    }
