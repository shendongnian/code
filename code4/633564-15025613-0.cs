    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace App
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<X> xs = new List<X>
                {
                    new X { Y = new Y {D = DateTime.Now}},
                    new X { Y = new Y {D = DateTime.Now}},
                    new X { Y = new Y {D = DateTime.Now}},
                };
                IEnumerable<DateTime> ds = xs.Select(x => x.Y.D).Distinct();
                var q = from d in ds
                        select new
                        {
                            D = d,
                            Count = xs.Count(x => x.Y.D.Equals(d))
                        };
                foreach (var i in q)
                {
                    Console.WriteLine(i);
                }
            }
            class X
            {
                public Y Y { get; set; }
            }
            class Y
            {
                public DateTime D { get; set; }
            }
        }
    }
