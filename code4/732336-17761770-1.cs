    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var list = new List<string>
            {
                "1,2,4,5,6,7,8,10,12,15,16", 
                "2,3,5,7,8,9,0,10,16,17",
                "4,5,89,12,13,1,2,3,6,7,10,16"
            };
            
            HashSet<string> set = new HashSet<string>(list[0].Split(','));
            foreach (var item in list.Skip(1))
            {
                set.IntersectWith(item.Split(','));
            }
            string result = string.Join(",", set);
            Console.WriteLine(result);
        }
    }
