    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        private enum TypeOfFact
        {
            Gdp,
            Other
        }
 
        private abstract class Fact
        {
            public virtual int Year { get; set; }
            public abstract TypeOfFact FactType { get; }
        }
        private class GdpFact : Fact
        {
            public override TypeOfFact FactType
            {
                get { return TypeOfFact.Gdp; }
            }
        }
        private class OtherFact : Fact
        {
            public override TypeOfFact FactType
            {
                get { return TypeOfFact.Other; }
            }
        }
        static void Main()
        {
            Ilist<Fact> facts = new List<Fact>
                {
                    new GdpFact { Year = 2010 },
                    new OtherFact { Year = 2010 },
                    new GdpFact { Year = 2009 },
                    new OtherFact { Year = 2009 },
                    new GdpFact { Year = 2011 },
                    new OtherFact { Year = 2011 },
                };
            const int interations = 1000000;
            var funcs = new List<Func<IList<Fact>, Fact>>
                {
                    ByList,
                    ByType,
                    ByEnum
                };
            // Warmup
            foreach (var func in funcs)
            {
               Measure(5, func, facts);
            }
            // Results
            foreach (var result in funcs.Select(f => new
                {
                    Description = f.Method.Name,
                    Ms = Measure(iterations, f, facts)
                }))
            {
                Console.WriteLine(
                    "{0} time = {1}ms",
                    result.Description,
                    result.Ms);
            }
        }
        private static long Measure(
            int iterations,
            Func<IList<Fact>, Fact> func,
            IList<Fact> facts)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < iterations; i++)
            {
                func.Invoke(facts);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        private static Fact ByType(IList<Fact> facts)
        {
            return facts.FirstOrDefault(f =>
                f.Year == 2011 && f is GdpFact);
        }
        private static Fact ByEnum(IList<Fact> facts)
        {
            return facts.FirstOrDefault(f =>
                f.Year == 2011 && f.FactType == TypeOfFact.Gdp);
        }
        private static Fact ByCast(IList<Fact> facts)
        {
            return facts.OfType<GdpFact>()
                .FirstOrDefault(f => f.Year == 2011);
        }
    }
