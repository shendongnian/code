    using System;
    using System.Linq;
    using Raven.Client.Document;
    using Raven.Client.Indexes;
    using Raven.Client.Linq;
    
    namespace ConsoleApplication1
    {
      public class Tick
      {
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public decimal Bid { get; set; }
      }
      
      /// <summary>
      /// This index is a true map/reduce, but its totals are for all time.
      /// You can't filter it by time range.
      /// </summary>
      class Ticks_Aggregate : AbstractIndexCreationTask<Tick, Ticks_Aggregate.Result>
      {
        public class Result
        {
          public decimal Min { get; set; }
          public decimal Max { get; set; }
          public int Count { get; set; }
        }
    
        public Ticks_Aggregate()
        {
          Map = ticks => from tick in ticks
                   select new
                        {
                          Min = tick.Bid,
                          Max = tick.Bid,
                          Count = 1
                        };
    
          Reduce = results => from result in results
                    group result by 0
                      into g
                      select new
                             {
                               Min = g.Min(x => x.Min),
                               Max = g.Max(x => x.Max),
                               Count = g.Sum(x => x.Count)
                             };
        }
      }
    
      /// <summary>
      /// This index can be filtered by time range, but it does not reduce anything
      /// so it will not be performant if there are many items inside the filter.
      /// </summary>
      class Ticks_ByTime : AbstractIndexCreationTask<Tick>
      {
        public class Result
        {
          public decimal Min { get; set; }
          public decimal Max { get; set; }
          public int Count { get; set; }
        }
    
        public Ticks_ByTime()
        {
          Map = ticks => from tick in ticks
                   select new {tick.Time};
    
          TransformResults = (database, ticks) =>
                     from tick in ticks
                     group tick by 0
                     into g
                     select new
                          {
                            Min = g.Min(x => x.Bid),
                            Max = g.Max(x => x.Bid),
                            Count = g.Count()
                          };
        }
      }
    
      class Program
      {
        private static void Main()
        {
          var documentStore = new DocumentStore { Url = "http://localhost:8080" };
          documentStore.Initialize();
          IndexCreation.CreateIndexes(typeof(Program).Assembly, documentStore);
    
    
          var today = DateTime.Today;
          var rnd = new Random();
    
          using (var session = documentStore.OpenSession())
          {
            // Generate 100 random ticks
            for (var i = 0; i < 100; i++)
            {
              var tick = new Tick { Time = today.AddMinutes(i), Bid = rnd.Next(100, 1000) / 100m };
              session.Store(tick);
            }
    
            session.SaveChanges();
          }
    
    
          using (var session = documentStore.OpenSession())
          {
            // Query items with a filter.  This will create a dynamic index.
            var fromTime = today.AddMinutes(20);
            var toTime = today.AddMinutes(80);
            var ticks = session.Query<Tick>()
              .Where(x => x.Time >= fromTime && x.Time <= toTime)
              .OrderBy(x => x.Time);
    
            // Ouput the results of the above query
            foreach (var tick in ticks)
              Console.WriteLine("{0} {1}", tick.Time, tick.Bid);
    
            // Get the aggregates for all time
            var total = session.Query<Tick, Ticks_Aggregate>()
              .As<Ticks_Aggregate.Result>()
              .Single();
            Console.WriteLine();
            Console.WriteLine("Totals");
            Console.WriteLine("Min: {0}", total.Min);
            Console.WriteLine("Max: {0}", total.Max);
            Console.WriteLine("Count: {0}", total.Count);
    
            // Get the aggregates with a filter
            var filtered = session.Query<Tick, Ticks_ByTime>()
              .Where(x => x.Time >= fromTime && x.Time <= toTime)
              .As<Ticks_ByTime.Result>()
              .Take(1024)  // max you can take at once
              .ToList()    // required!
              .Single();
            Console.WriteLine();
            Console.WriteLine("Filtered");
            Console.WriteLine("Min: {0}", filtered.Min);
            Console.WriteLine("Max: {0}", filtered.Max);
            Console.WriteLine("Count: {0}", filtered.Count);
          }
    
          Console.ReadLine();
        }
      }
    }
