    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        private readonly static Random r = new Random();
        public static void Main(string[] args)
        {
            int N = 250;
            var work = Enumerable.Range(1,N).Select(x => r.Next(0, 6)).ToList();
            var chunks = work.Select((i,o) => new { Index=i, Obj=o })
                .GroupBy(e => e.Index / 10)
                .Select(group => group.Select(e => e.Obj).ToList())
                .ToList();
        }
    }
