    public abstract class Collection<TCollection, TChild>
        where TCollection : Collection<TCollection, TChild>, new()
    {
        protected Collection()
        {
            List=new List<TChild>();
        }
        protected List<TChild> List { get; set; }
        public TCollection Where(Func<TChild, bool> predicate)
        {
            var result=new TCollection();
            result.List.AddRange(List.Where(predicate));
            return result;
        }
        public void Add(TChild item) { List.Add(item); }
        public void AddRange(IEnumerable<TChild> collection) { List.AddRange(collection); }
    }
    public class Waffle
    {
        public double Temperature { get; set; }
    }
    public class WafflesCollection : Collection<WafflesCollection, Waffle>
    {
        public WafflesCollection BurnedWaffles
        {
            get
            {
                return Where((w) => w.Temperature>108);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WafflesCollection waffles=new WafflesCollection();
            // Count = 3
            waffles.Add(new Waffle() { Temperature=100 });
            waffles.Add(new Waffle() { Temperature=120 });
            waffles.Add(new Waffle() { Temperature=105 });
            var burned=waffles.BurnedWaffles;
            // Count = 1
        }
    }
