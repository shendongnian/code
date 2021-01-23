    public enum SortMethod
    {
        Newest,
        Oldest,
        LowestPrice,
    }
    
    public class Foo
    {
        public DateTime Date {get;set;}
        public decimal Price {get;set;}
    }
    ...
    var strategyMap = new Dictionary<SortMethod, Func<IEnumerable<Foo>, IEnumerable<Foo>>>
                      {
                          { SortMethod.Newest, x => x.OrderBy(y => y.Date) },
                          { SortMethod.Oldest, x => x.OrderByDescending(y => y.Date) },
                          { SortMethod.LowestPrice, x => x.OrderBy(y => y.Price) }
                      };
    ...
    var unsorted = new List<Foo>
                   {
                       new Foo { Date = new DateTime(2012, 1, 3), Price = 10m },
                       new Foo { Date = new DateTime(2012, 1, 1), Price = 30m },
                       new Foo { Date = new DateTime(2012, 1, 2), Price = 20m }
                   };
    var sorted = strategyMap[SortMethod.LowestPrice](unsorted);
