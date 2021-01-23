    public class Foo
    {
        public Foo(IEnumerable<DateTime> dates)
        {
            this.Dates = new List<DateTime>(dates);
        }
    
        public IList<DateTime> Dates { get; private set; }
    
        public static IEnumerable<Foo> FindFoos(IList<Foo> source)
        {
            return from f in source
                   where f.Dates.Distinct().Count() < f.Dates.Count
                   select f;
        }
    }
