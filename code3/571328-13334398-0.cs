    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Item
    {
        public List<int> Values { get; set; }
        public double Support { get; set; }
    }
          
    class Test
    {
        static void Main()
        {
            List<Item> list = new List<Item>
            {
                new Item { Values = new List<int>{1, 2, 3},
                           Support = 0.1 }
            };
            
            var check = new Item { Values = list[0].Values,
                                   Support = list[0].Support };
            
            bool found = list.Any(a => a.Values == check.Values);
            Console.WriteLine(found);
        }
    }
