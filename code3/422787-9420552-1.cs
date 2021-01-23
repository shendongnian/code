    using System;
    using System.Linq;
    
    class Test
    {
        public static void Main()        
        {
            int[] A = {6, 7, 10};
            int[] B = {2, 3};
            
            var query = A.SelectMany(a => B, (a, b) => a - b)
                         .Where(x => x > 3);
    
            foreach (var result in query)
            {
                Console.WriteLine(result);
            }
        }
    }
