    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            var firstRange = Enumerable.Range(1, 100);
            var secondRange = Enumerable.Range(1, 200);
            var thirdRange = Enumerable.Range(180, 300);
            var fourthRange = Enumerable.Range(301, 400);
    
            Console.WriteLine(!IsContainInRange(firstRange, secondRange));      
            Console.WriteLine(!IsContainInRange(thirdRange, secondRange));
            Console.WriteLine(!IsContainInRange(fourthRange, secondRange));
        }
    
        private static bool IsContainInRange(IEnumerable<int> range1, IEnumerable<int> range2)
        {
            return (from r1 in range1
                     join r2 in range2 on r1 equals r2 
                     select r1).Any();
        }
    }
