    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public enum City
    {
           a=1,
           b=1,
           c=1,
           d=2,
           e=2,
           f=2,
    }
    
    class Test
    {
        static void Main()
        {
            // Or GetNames((City) 2)
            foreach (var name in GetNames(City.a))
            {
                Console.WriteLine(name);
            }
        }
        
        static IEnumerable<string> GetNames<T>(T value) where T : struct
        {
            return Enum.GetNames(typeof(T))
                       .Where(name => Enum.Parse(typeof(T), name).Equals(value));
        }
    }
