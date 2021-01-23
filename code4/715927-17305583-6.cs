    using System;
    using System.Collections.Generic;
    using System.Linq;
     
    public class Demo
    {
        public static void Main()
        {
            int tries = 100;
            int count = 50;
            int size = 1000;
            Random rnd = new Random();
            List<int>[] list;
            long s;
            list = new List<int>[count];
            for(int i=0; i<count; i++)
            {
                list[i] = new List<int>();
                for(int x=0; x<size; x++)
                {
                    int n = rnd.Next();
                    list[i].Add(n);
                }
                if((i % 10) == 0 && i > 0)
                { // make repeated lists for the uniqueness check
                    list[i-1] = new List<int>(list[i]);
                    list[i-1].Reverse();
                }
            }
            s = DateTime.Now.Ticks;
            for(int x=0; x<tries; x++)
                Test1(list);
            Console.WriteLine( (DateTime.Now.Ticks-s).ToString() );
     
            list = new List<int>[count];
            for(int i=0; i<count; i++)
            {
                list[i] = new List<int>();
                for(int x=0; x<size; x++)
                {
                    int n = rnd.Next();
                    list[i].Add(n);
                }
                if((i % 10) == 0 && i > 0)
                { // make repeated lists for the uniqueness check
                    list[i-1] = new List<int>(list[i]);
                    list[i-1].Reverse();
                }
            }
            s = DateTime.Now.Ticks;
            for(int x=0; x<tries; x++)
                Test2(list);
            Console.WriteLine( (DateTime.Now.Ticks-s).ToString() );
        }
        public static List<List<int>> Test1(List<int>[] lists)
        {
            var result = new List<List<int>>();
            foreach(var list in lists)
            {
                list.Sort();
                if(!result.Any(elm => elm.SequenceEqual(list)))
                    result.Add(list);
            }
            return result;
        }
        public static List<HashSet<int>> Test2(List<int>[] lists)
        {
            var result = new List<HashSet<int>>();
            foreach(var list in lists)
            {
                result.Add(new HashSet<int>(list));
            }
            result = result.Distinct(HashSet<int>.CreateSetComparer()).ToList();
            return result;
        }
    }
