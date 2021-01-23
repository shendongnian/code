    public class TestClient
    {
        public static void Main(string[] args)
        {
            var p = new List<IItem>();
            p.Add(new Item { Name = "Aaron" });
            p.Add(new Item { Name = "Jeremy" });
    
            var ims = p.ToEntitySetFromInterface<Item, IItem>();
    
            foreach (var itm in ims)
            {
                Console.WriteLine(itm);
            }
    
            Console.ReadKey(true);
        }
    }
    
    public class Item : IItem
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    
    public interface IItem
    {
    }
    
    public static class ExtMethod
    {
        public static EntitySet<T> ToEntitySetFromInterface<T, U>(this IList<U> source) where T : class, U
        {
            var es = new EntitySet<T>();
            IEnumerator<U> ie = source.GetEnumerator();
            while (ie.MoveNext())
            {
                es.Add((T)ie.Current);
            }
            return es;
        }
    }
