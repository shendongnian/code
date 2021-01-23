    // access between these two is almost identical
    public class Foo
    {
        public readonly static IDictionary<string, int> bar =
            new Dictionary<string, int>();
        public static IDictionary<string, int> Bar
        {
             get { return bar; }
        }
    }
