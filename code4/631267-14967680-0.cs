    using System;
    using System.Collections.Generic;
    
    class DateEqualityComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Date == y.Date;
        }
        
        public int GetHashCode(DateTime obj)
        {
            return obj.Date.GetHashCode();
        }
    }
    
    class Test
    {
        static void Main()
        {
            var key1 = new DateTime(2013, 2, 19, 5, 13, 10);
            var key2 = new DateTime(2013, 2, 19, 21, 23, 30);
            
            var comparer = new DateEqualityComparer();
            var dictionary = new Dictionary<DateTime, string>(comparer);
            dictionary[key1] = "Foo";
            Console.WriteLine(dictionary[key2]); // Prints Foo
        }
        
    }
