    public class Poco
        {
            public int TypeId { get; set; }
            public int CustomerId { get; set; }
            public bool Active { get; set; }
        }
    public class Filter<T>
    {
        private List<Func<T, bool>> filters = new List<Func<T, bool>>();
        public void AddFilter(Func<T, bool> filter)
        {
            this.filters.Add(filter);
        }
        public bool PredicateFilter(T item)
        {
            return filters.All(x => x(item));
        }
    }
    static void Main(string[] args)
    {
        var list = new List<Poco>() { new Poco { Active = true, CustomerId = 1, TypeId = 1 } };
        var filter = new Filter<Poco>();
        filter.AddFilter(x => x.Active == false);
        filter.AddFilter(x => x.CustomerId == 1);
        filter.AddFilter(x => x.TypeId == 1);
        var item = list.Where(x => filter.PredicateFilter(x));
        
        
        Console.Read();
    }
