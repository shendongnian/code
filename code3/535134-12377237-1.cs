    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace AnswersOnSO
    {
        public class Class1
        {
            public static void Main(string []args)
            {
    //            How to check if list A contains any value from list B?
    //            e.g. something like A.contains(a=>a.id = B.id)?
                List<int> a = new List<int> {1,2,3,4};
                List<int> b = new List<int> {2,5};
                int times = 10000000;
                DateTime dtAny = DateTime.Now;
                for (int i = 0; i < times; i++)
                {
                    var aContainsBElements = a.Any(b.Contains);
                }
                var time = (DateTime.Now - dtAny).TotalSeconds;
                DateTime dt2 = DateTime.Now;
                for (int i = 0; i < times; i++)
                {
                    var aContainsBElements = a.Intersect(b).Any();
                }
                var time2 = (DateTime.Now - dt2).TotalSeconds;
                // time1: 1.1470656 secs
                // time2: 3.1431798 sec
            }
        }
    }
