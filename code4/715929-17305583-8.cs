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
            long s, t;
            t = 0;
            for(int x=0; x<tries; x++)
            {
                list = new List<int>[count];
                for(int y=0; y<count; y++)
                {
                    list[y] = new List<int>();
                    for(int z=0; z<size; z++)
                    {
                        int n = rnd.Next();
                        list[y].Add(n);
                    }
                    if((y % 10) == 0 && y > 0)
                    { // make repeated lists for the uniqueness check
                        list[y-1] = new List<int>(list[y]);
                        list[y-1].Reverse();
                    }
                }
                s = DateTime.Now.Ticks;
                Test1(list);
                t += (DateTime.Now.Ticks - s);
            }
            Console.WriteLine( t.ToString() );
            t = 0;
            for(int x=0; x<tries; x++)
            {
                list = new List<int>[count];
                for(int y=0; y<count; y++)
                {
                    list[y] = new List<int>();
                    for(int z=0; z<size; z++)
                    {
                        int n = rnd.Next();
                        list[y].Add(n);
                    }
                    if((y % 10) == 0 && y > 0)
                    { // make repeated lists for the uniqueness check
                        list[y-1] = new List<int>(list[y]);
                        list[y-1].Reverse();
                    }
                }
                s = DateTime.Now.Ticks;
                Test2(list);
                t += (DateTime.Now.Ticks - s);
            }
            Console.WriteLine( t.ToString() );        
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
