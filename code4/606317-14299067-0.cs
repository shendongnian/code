    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Data
    {
        public Data(int cust, int item)
        {
            item_id = item;
            cust_id = cust;
        }
        public int item_id { get; set; }
        public int cust_id { get; set; }
    
        static void Main(string[] args)
        {
            var data = new List<Data>
                           {new Data(1,1),new Data(1,2),new Data(1,3),
                            new Data(2,4),new Data(2,2),new Data(3,5),
                            new Data(3,1),new Data(3,2),new Data(4,1),
                            new Data(4,2),new Data(5,5),new Data(5,1)};
    
               (from a1 in data
                from a2 in data
                where a2.cust_id == a1.cust_id && a2.item_id != a1.item_id && a1.item_id < a2.item_id
                group new {a1, a2} by new {item1 = a1.item_id, item2 = a2.item_id}
                into g
                select new {g.Key.item1, g.Key.item2, count = g.Count()})
                .ToList()
                .ForEach(x=>Console.WriteLine("{0} {1} {2}",x.item1,x.item2,x.count))
                ;
               Console.Read();
        }
    }
