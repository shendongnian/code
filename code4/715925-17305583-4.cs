    using System;
    using System.Collections.Generic;
    using System.Linq;
     
    public class Demo
    {
        public static void Main()
        {
            int count = 100000;
            long s;
            s = DateTime.Now.Ticks;
            for(int x=0; x<count; x++)
                Test1();
            Console.WriteLine( (DateTime.Now.Ticks-s).ToString() );
            s = DateTime.Now.Ticks;
            for(int x=0; x<count; x++)
                Test2();
            Console.WriteLine( (DateTime.Now.Ticks-s).ToString() );
        }
        public static List<List<int>> Test1()
        {
            var list1 = new List<int>{1,2,3,4,5};
            var list2 = new List<int>{2,3};
            var list3 = new List<int>{3,2};
            var result = new List<List<int>>();
            list1.Sort();
            list2.Sort();
            list3.Sort();
            if(!result.Any(elm => elm.SequenceEqual(list1)))
                result.Add(list1);
            if(!result.Any(elm => elm.SequenceEqual(list2)))
                result.Add(list2);
            if(!result.Any(elm => elm.SequenceEqual(list3)))
                result.Add(list3);
            return result;
        }
        public static List<HashSet<int>> Test2()
        {
            var list1 = new List<int>{1,2,3,4,5};
            var list2 = new List<int>{2,3};
            var list3 = new List<int>{3,2};
            var result = new List<HashSet<int>>();
            result.Add(new HashSet<int>(list1));
            result.Add(new HashSet<int>(list2));
            result.Add(new HashSet<int>(list3));
            result = result.Distinct(HashSet<int>.CreateSetComparer()).ToList();
            return result;
        }
    }
