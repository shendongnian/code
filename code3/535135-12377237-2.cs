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
                var a = new List<int> {1,2,3,4};
                var b = new List<int> {2,5};
                var times = 10000000;
                DateTime dtAny = DateTime.Now;
                for (var i = 0; i < times; i++)
                {
                    var aContainsBElements = a.Any(b.Contains);
                }
                var timeAny = (DateTime.Now - dtAny).TotalSeconds;
                DateTime dtIntersect = DateTime.Now;
                for (var i = 0; i < times; i++)
                {
                    var aContainsBElements = a.Intersect(b).Any();
                }
                var timeIntersect = (DateTime.Now - dtIntersect).TotalSeconds;
                // timeAny: 1.1470656 secs
                // timeIn.: 3.1431798 secs
            }
        }
    }
