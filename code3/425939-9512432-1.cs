    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Foo>()
            {
                new Foo("Book", 23),
                new Foo("Book", 22),
                new Foo("Book", 19)
            };
            foreach(var element in list.Distinct(new Comparer()))
            {
                Console.WriteLine(element.Type + " " + element.Value);
            }
        }
    }
    public class Foo
    {
        public Foo(string type, int value)
        {
            this.Type = type;
            this.Value = value;
        }
        public string Type { get; private set; }
        public int Value { get; private set; }
    }
    public class Comparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            if(x == null || y == null)
                return x == y;
            else
                return x.Type == y.Type;
        }
        public int GetHashCode(Foo obj)
        {
            return obj.Type.GetHashCode();
        }
    }
